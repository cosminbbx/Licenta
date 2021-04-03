using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.ServicePackage.Dto;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Web.Models.ServicePackage;
using DigitalEventPlaner.Web.Models.Services;
using DigitalEventPlaner.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class ServiceManageController : Controller
    {
        private readonly IServiceService serviceService;
        private readonly IServicePackageService servicePackageService;
        public ServiceManageController(IServiceService serviceService, IServicePackageService servicePackageService)
        {
            this.serviceService = serviceService;
            this.servicePackageService = servicePackageService;
        }

        [Authorize(Roles = "Service")]
        public IActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var serviceWrapperList = serviceService.GetServiceWrappersByUserId(userId);
            var serviceViewModelList = new List<ServiceWrapperViewModel>();
            foreach(var serviceWrapper in serviceWrapperList)
            {
                var servicePackagesViewModels = new List<ServicePackageViewModel>();
                serviceWrapper.ServicePackages.ForEach(x => servicePackagesViewModels.Add(new ServicePackageViewModel().InjectFrom(x) as ServicePackageViewModel));
                serviceViewModelList.Add(new ServiceWrapperViewModel()
                {
                    Service = new ServiceViewModel().InjectFrom(serviceWrapper.Service) as ServiceViewModel,
                    ServicePackages = servicePackagesViewModels
                });
            }
            return View(serviceViewModelList);
        }

        [HttpGet]
        [Authorize(Roles = "Service")]
        public IActionResult AddService()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var model = new ServiceViewModel() { UserId = userId };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddService(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                serviceService.Create(new ServiceDto().InjectFrom(model) as ServiceDto);
                return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
            }
            return View();
        }

        [Authorize(Roles = "Service")]
        [HttpGet]
        public IActionResult EditService(int Id)
        {
            var service = serviceService.GetById(Id);
            if(service == null)
            {
                return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
            }
            return View(new ServiceViewModel().InjectFrom(service) as ServiceViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Service")]
        public IActionResult EditService(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                serviceService.Update(new ServiceDto().InjectFrom(model) as ServiceDto);
                return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
            }
            return View();
        }

        [Authorize(Roles = "Service")]
        public IActionResult DeleteService(int Id)
        {
            serviceService.SoftDelete(Id);
            return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
        }

        [Authorize(Roles = "Service")]
        public IActionResult DeletedServices()
        {
            var deletedList = serviceService.GetDeletedByUserId(Int32.Parse(HttpContext.User.Claims.ToList()[0].Value));
            var serviceViewModelList = new List<ServiceViewModel>();
            foreach (var service in deletedList)
            {
                serviceViewModelList.Add(new ServiceViewModel().InjectFrom(service) as ServiceViewModel);
            }
            return View(serviceViewModelList);
        }

        [Authorize(Roles = "Service")]
        public IActionResult Undelete(int Id)
        {
            serviceService.Undelete(Id);
            return RedirectToAction(nameof(ServiceManageController.DeletedServices), "ServiceManage");
        }

        
        [HttpGet]
        [Authorize(Roles = "Service")]
        public IActionResult AddServicePackage(int Id)
        {
            var model = new ServicePackageViewModel() { ServiceId = Id };
            return View(model);
        }
        
        [HttpPost]
        [Authorize(Roles = "Service")]
        public IActionResult AddServicePackage(ServicePackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new ServicePackageDto().InjectFrom(model) as ServicePackageDto;
                service.Id = 0;
                servicePackageService.Create(service);
                return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
            }
            return View();
        }
        
        [HttpGet]
        [Authorize(Roles = "Service")]
        public IActionResult EditServicePackage(int Id)
        {
            var model = new ServicePackageViewModel().InjectFrom(servicePackageService.GetById(Id)) as ServicePackageViewModel;
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Service")]
        public IActionResult EditServicePackage(ServicePackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var service = new ServicePackageDto().InjectFrom(model) as ServicePackageDto;
                servicePackageService.Update(service);
                return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
            }
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Service")]
        public IActionResult DeleteServicePackage(int Id)
        {
            servicePackageService.SoftDelete(Id);
            return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
        }

        [HttpGet]
        [Authorize(Roles = "Service")]
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