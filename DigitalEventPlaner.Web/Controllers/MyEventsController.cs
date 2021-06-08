using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.BlobService;
using DigitalEventPlaner.Services.Services.ContainerName;
using DigitalEventPlaner.Services.Services.ContainerName.Dto;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.EventService.Dto;
using DigitalEventPlaner.Services.Services.FaceRecognition;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Web.Helpers;
using DigitalEventPlaner.Web.Models.MyEvents;
using DigitalEventPlaner.Web.Models.ServicePackage;
using DigitalEventPlaner.Web.Models.Services;
using DigitalEventPlaner.Web.Models.User;
using DigitalEventPlaner.Web.Models.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class MyEventsController : Controller
    {
        private readonly IServiceService serviceService;
        private readonly IEventServiceService eventServiceService;
        private readonly IServicePackageService servicePackageService;
        private readonly IBlobService blobService;
        private readonly IContainerNameService containerNameService;
        private readonly IFaceRecognitionService faceRecognitionService;
        public MyEventsController(IServiceService serviceService, IEventServiceService eventServiceService, IServicePackageService servicePackageService, IBlobService blobService, IContainerNameService containerNameService, IFaceRecognitionService faceRecognitionService)
        {
            this.serviceService = serviceService;
            this.eventServiceService = eventServiceService;
            this.servicePackageService = servicePackageService;
            this.blobService = blobService;
            this.containerNameService = containerNameService;
            this.faceRecognitionService = faceRecognitionService;
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var eventWrappers = serviceService.GetEventWrappersByUserId(userId);

            var viewModelList = GeneralHelper.MapEventWrapperList(eventWrappers);
            return View(viewModelList);
        }

        private List<ServiceWrapperViewModel> GetServiceWrapperViewModels(DateTime date, string eventTypeString, int NOP, int packageToAvoid)
        {
            var serviceWrapperList = serviceService.GetServiceWrappersByDateAndNOP(date, eventTypeString, NOP);
            var serviceViewModelList = new List<ServiceWrapperViewModel>();
            foreach (var serviceWrapper in serviceWrapperList)
            {
                var servicePackagesViewModels = new List<ServicePackageViewModel>();
                serviceWrapper.ServicePackages.ForEach(x => { if (x.Id != packageToAvoid) { servicePackagesViewModels.Add(new ServicePackageViewModel().InjectFrom(x) as ServicePackageViewModel); } });
                serviceViewModelList.Add(new ServiceWrapperViewModel()
                {
                    Service = new ServiceViewModel().InjectFrom(serviceWrapper.Service) as ServiceViewModel,
                    User = new UserViewModel().InjectFrom(serviceWrapper.User) as UserViewModel,
                    ProfilePictureUri = GetProfilePictureUri(serviceWrapper.User.Id).Result,
                    ServicePackages = servicePackagesViewModels
                });
            }
            return serviceViewModelList;
        }

        private async Task<string> GetProfilePictureUri(int userId)
        {
            var profilePicture = await blobService.GetProfilePicture(userId);
            return profilePicture.First();
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult ChangeService(int eventServiceId, ServiceType eventType, DateTime eventDate)
        {
            var eventService = eventServiceService.GetById(eventServiceId);
            var serviceWrappers = GetServiceWrapperViewModels(eventDate, eventType.ToString(), 0, eventService.ServicePackageId);

            TempData.Put("ServiceWrappers", serviceWrappers);

            var viewModel = new ChangeServiceViewModel()
            {
                ServiceType = eventType,
                ServiceWrappers = serviceWrappers
            };
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult ChangeService(ChangeServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ServicePackageSelected.Count() > 1)
                {
                    ModelState.AddModelError("ServicePackageSelected", "Select just one type of service!");

                    var serviceWrappersAtError = TempData.Get<List<ServiceWrapperViewModel>>("ServiceWrappers");
                    var viewModelAtError = new ChangeServiceViewModel()
                    {
                        ServiceType = model.ServiceType,
                        ServiceWrappers = serviceWrappersAtError
                    };
                    TempData.Put("ServiceWrappers", serviceWrappersAtError);
                    return View(viewModelAtError);
                }
                var servicePackage = servicePackageService.GetById(model.ServicePackageSelected[0]);
                eventServiceService.UpdateServicePackage(model.EventServiceId, servicePackage.ServiceId, servicePackage.Id);
                return RedirectToAction(nameof(MyEventsController.Index), "MyEvents");
            }
            var serviceWrappers = TempData.Get<List<ServiceWrapperViewModel>>("ServiceWrappers");
            var viewModel = new ChangeServiceViewModel()
            {
                ServiceType = model.ServiceType,
                ServiceWrappers = serviceWrappers
            };
            TempData.Put("ServiceWrappers", serviceWrappers);
            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> UploadForSmartRating(UploadViewModel model)
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var imageNames = await UploadSmartRateImages(model.Imagelist, userId);
            var smartRateValue = await faceRecognitionService.GetSmartRateForImages(imageNames);
            serviceService.UpdateSmartRating(smartRateValue, model.EventId);

            return RedirectToAction(nameof(MyEventsController.Index), "MyEvents");
        }

        private async Task<List<string>> UploadSmartRateImages(List<IFormFile> imagelist, int userId)
        {
            var imageList = new List<string>();
            foreach (var image in imagelist)
            {
                using (var stream = new MemoryStream())
                {
                    await image.CopyToAsync(stream);
                    var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    await blobService.UploadSmartRateImage(stream.GetBuffer(), image.FileName, fileName);

                    var smartRatingDto = new ContainerNameDto()
                    {
                        Name = fileName,
                        ContainerType = ContainerType.SmartRateImage,
                        UserId = userId
                    };
                    containerNameService.Create(smartRatingDto);
                    imageList.Add(fileName);
                }
            }
            return imageList;
        }
    }
}
