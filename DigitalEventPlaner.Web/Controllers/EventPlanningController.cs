using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.BlobService;
using DigitalEventPlaner.Services.Services.Event;
using DigitalEventPlaner.Services.Services.Event.Dto;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.MLService;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Web.Models.EventPlanning;
using DigitalEventPlaner.Web.Models.ServicePackage;
using DigitalEventPlaner.Web.Models.Services;
using DigitalEventPlaner.Web.Models.User;
using DigitalEventPlaner.Web.Models.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class EventPlanningController : Controller
    {
        private readonly IMLService mLService;
        private readonly IServiceService serviceService;
        private readonly IEventService eventService;
        private readonly IServicePackageService servicePackageService;
        private readonly IBlobService blobService;
        public EventPlanningController(IMLService mLService,IServiceService serviceService, IEventService eventService, IServicePackageService servicePackageService, IBlobService blobService)
        {
            this.mLService = mLService;
            this.serviceService = serviceService;
            this.eventService = eventService;
            this.servicePackageService = servicePackageService;
            this.blobService = blobService;
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Step1()
        {
            var viewModel = new EventPlanningStep1ViewModel();
            viewModel.ServiceTypes = GetServiceTypes(serviceService.GetAll());
            return View(viewModel);
        }

        private List<string> GetServiceTypes(List<ServiceDto> services)
        {
            var serviceTypesList = new List<string>();
            foreach (ServiceType type in Enum.GetValues(typeof(ServiceType)))
            {
                if (services.Any(x => x.ServiceType == type))
                {
                    serviceTypesList.Add(type.ToString());
                }
            }
            return serviceTypesList;
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Step1(EventPlanningStep1ViewModel model)
        {
            //var model = new EventPlanningStep1ViewModel();
            //model.EventTypes = Enum.GetValues(typeof(ServiceType)).Cast<string>().ToList();
            if (ModelState.IsValid)
            {
                //model.Estimation = mLService.BugetEstimation(new Services.Services.Event.Dto.EventDto()
                //{
                    //UserId = model.UserId,
                    //NumberOfServices = model.EventTypesSelected.Count(),
                    //Participants = model.Participants
                //});
                model.UserId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
                //var viewModel = new EventPlanningStep2ViewModel() { Estimation = estimation, Step1 = new Step1Dto().InjectFrom(model) as Step1Dto };
                return RedirectToAction(nameof(EventPlanningController.Step2), "EventPlanning", model);
            }
            model.ServiceTypes = GetServiceTypes(serviceService.GetAll());
            return View(model);
        }

        private List<ServiceWrapperViewModel> GetServiceWrapperViewModels(DateTime date, string eventTypeString, int NOP)
        {
            var serviceWrapperList = serviceService.GetServiceWrappersByDateAndNOP(date, eventTypeString, NOP);
            var serviceViewModelList = new List<ServiceWrapperViewModel>();
            foreach (var serviceWrapper in serviceWrapperList)
            {
                var servicePackagesViewModels = new List<ServicePackageViewModel>();
                serviceWrapper.ServicePackages.ForEach(x => servicePackagesViewModels.Add(new ServicePackageViewModel().InjectFrom(x) as ServicePackageViewModel));
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

        [Authorize(Roles = "Customer")]
        public IActionResult Step2(EventPlanningStep1ViewModel model)
        {
            var serviceViewModelList = GetServiceWrapperViewModels(DateTime.Parse(model.EventDate), model.ServiceTypes[0], model.Participants);

            foreach(var viewModel in serviceViewModelList)
            {
                viewModel.ProfilePictureUri = GetProfilePictureUri(viewModel.User.Id).Result;
            }

            //model.EventTypesSelected.ForEach(x => wrapperDict[(ServiceType)Enum.Parse(typeof(ServiceType), x)] = serviceService.GetServiceWrappersByDateAndNOP(DateTime.Parse(model.EventDate), x,model.Participants));
            TempData.Put("Step1", new Step1Dto().InjectFrom(model) as Step1Dto);
            TempData.Put("ServiceWrappers", serviceViewModelList);
            TempData.Put("ServicePackageDict", new Dictionary<int, int>());
            return View(new EventPlanningStep2ViewModel()
            {
                Step1 = new Step1Dto().InjectFrom(model) as Step1Dto,
                ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), model.ServiceTypesSelected[0]),
                ServiceSelectedIndex = 0,
                ServiceWrappers = serviceViewModelList,
                BugetNeeded = 0
            });
        }

        private async Task<string> GetProfilePictureUri(int userId)
        {
            var profilePicture = await blobService.GetProfilePicture(userId);
            return profilePicture.First();
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult Step2(EventPlanningStep2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.ServicePackageSelected.Count() > 1)
                {
                    ModelState.AddModelError("ServicePackageSelected", "Select just one type of service!");

                    return ResetStep2(model);
                }

                var step1 = TempData.Get<Step1Dto>("Step1");
                model.Step1 = step1;
                
                var servicePackageDict = TempData.Get<Dictionary<int, int>>("ServicePackageDict");
                servicePackageDict[(int)model.ServiceType] = model.ServicePackageSelected[0];
                TempData.Put("ServicePackageDict", servicePackageDict);

                model.BugetNeeded = model.BugetNeeded + model.Step1.Participants * servicePackageService.GetById(model.ServicePackageSelected[0]).PricePerParticipant;
                if (model.ServiceSelectedIndex == step1.ServiceTypesSelected.Count() - 1)
                {
                    var ecentDto = new EventDto()
                    {
                        UserId = step1.UserId,
                        EventType = (EventType)Enum.Parse(typeof(EventType), step1.EventTypesSelected[0]),
                        NumberOfServices = step1.ServiceTypesSelected.Count(),
                        Participants = step1.Participants,
                        BugetNeeded = model.BugetNeeded,
                        Status = EventStatus.Planning,
                        EventDate = DateTime.Parse(step1.EventDate),
                        IsDeleted = false
                    };
                    eventService.Create(ecentDto, servicePackageDict);

                    return RedirectToAction(nameof(EventPlanningController.Step3), "EventPlanning", new { buget = model.BugetNeeded });
                }

                var serviceWrappers = GetServiceWrapperViewModels(DateTime.Parse(model.Step1.EventDate), model.Step1.ServiceTypesSelected[model.ServiceSelectedIndex + 1], model.Step1.Participants);

                TempData.Put("ServiceWrappers", serviceWrappers);
                TempData.Put("Step1", step1);
                //model.EventTypesSelected.ForEach(x => wrapperDict[(ServiceType)Enum.Parse(typeof(ServiceType), x)] = serviceService.GetServiceWrappersByDateAndNOP(DateTime.Parse(model.EventDate), x,model.Participants));
                return View(new EventPlanningStep2ViewModel()
                {
                    Step1 = step1,
                    ServiceSelectedIndex = model.ServiceSelectedIndex + 1,
                    ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), model.Step1.ServiceTypesSelected[model.ServiceSelectedIndex + 1]),
                    ServiceWrappers = serviceWrappers,
                    BugetNeeded = model.BugetNeeded
                });
            }
            return ResetStep2(model);
        }

        private IActionResult ResetStep2(EventPlanningStep2ViewModel model)
        {
            var step1 = TempData.Get<Step1Dto>("Step1");
            TempData.Put("Step1", step1);
            var serviceWrappers = TempData.Get<List<ServiceWrapperViewModel>>("ServiceWrappers");
            var serviceTypeValue = model.ServiceSelectedIndex < step1.EventTypesSelected.Count() ? model.ServiceSelectedIndex : model.ServiceSelectedIndex - 1;
            var parsedType = (ServiceType)Enum.Parse(typeof(ServiceType), step1.ServiceTypesSelected[serviceTypeValue]);
            return View(new EventPlanningStep2ViewModel()
            {
                Step1 = step1,
                ServiceType = parsedType,
                ServiceSelectedIndex = model.ServiceSelectedIndex,
                ServiceWrappers = serviceWrappers,
            });
        }
        [Authorize(Roles = "Customer")]
        [HttpGet]
        public IActionResult Step3(int buget)
        {
            return View(buget);
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        public IActionResult ServiceDetails(int Id)
        {
            var dto = serviceService.GetServiceWrapperByServiceId(Id);
            var servicePackagesViewModels = new List<ServicePackageViewModel>();
            dto.ServicePackages.ForEach(x => servicePackagesViewModels.Add(new ServicePackageViewModel().InjectFrom(x) as ServicePackageViewModel));
            var model = new ServiceWrapperViewModel()
            {
                Service = new ServiceViewModel().InjectFrom(dto.Service) as ServiceViewModel,
                ServicePackages = servicePackagesViewModels
            };
            return View(model);
        }
    }
}
