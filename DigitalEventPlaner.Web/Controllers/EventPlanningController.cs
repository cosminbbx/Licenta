using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.MLService;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Web.Models.EventPlanning;
using DigitalEventPlaner.Web.Models.ServicePackage;
using DigitalEventPlaner.Web.Models.Services;
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
        public EventPlanningController(IMLService mLService,IServiceService serviceService)
        {
            this.mLService = mLService;
            this.serviceService = serviceService;
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Step1()
        {
            return View(new EventPlanningStep1ViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Step1(EventPlanningStep1ViewModel model)
        {
            //var model = new EventPlanningStep1ViewModel();
            //model.EventTypes = Enum.GetValues(typeof(ServiceType)).Cast<string>().ToList();
            if (ModelState.IsValid)
            {
                model.Estimation = mLService.BugetEstimation(new Services.Services.Event.Dto.EventDto()
                {
                    UserId = model.UserId,
                    NumberOfServices = model.EventTypesSelected.Count(),
                    Participants = model.Participants
                });
                //var viewModel = new EventPlanningStep2ViewModel() { Estimation = estimation, Step1 = new Step1Dto().InjectFrom(model) as Step1Dto };
                return RedirectToAction(nameof(EventPlanningController.Step2), "EventPlanning", model);
            }
            return View(model);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Step2(EventPlanningStep1ViewModel model)
        {
            var wrapperDict = new Dictionary<ServiceType, List<ServiceWrapper>>();

            var serviceWrapperList = serviceService.GetServiceWrappersByDateAndNOP(DateTime.Parse(model.EventDate), model.EventTypesSelected[0], model.Participants);
            var serviceViewModelList = new List<ServiceWrapperViewModel>();
            foreach (var serviceWrapper in serviceWrapperList)
            {
                var servicePackagesViewModels = new List<ServicePackageViewModel>();
                serviceWrapper.ServicePackages.ForEach(x => servicePackagesViewModels.Add(new ServicePackageViewModel().InjectFrom(x) as ServicePackageViewModel));
                serviceViewModelList.Add(new ServiceWrapperViewModel()
                {
                    Service = new ServiceViewModel().InjectFrom(serviceWrapper.Service) as ServiceViewModel,
                    ServicePackages = servicePackagesViewModels
                });
            }

            //model.EventTypesSelected.ForEach(x => wrapperDict[(ServiceType)Enum.Parse(typeof(ServiceType), x)] = serviceService.GetServiceWrappersByDateAndNOP(DateTime.Parse(model.EventDate), x,model.Participants));
            TempData.Put("Step1", new Step1Dto().InjectFrom(model) as Step1Dto);
            TempData.Put("ServiceWrappers", serviceViewModelList);
            return View(new EventPlanningStep2ViewModel()
            {
                Step1 = new Step1Dto().InjectFrom(model) as Step1Dto,
                ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), model.EventTypesSelected[0]),
                ServiceSelectedIndex = model.EventTypesSelected.Count() > 2 ? 1 : 0,
                ServiceWrappers = serviceViewModelList,
            });
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public IActionResult Step2(EventPlanningStep2ViewModel model)
        {
            var step1 = TempData.Get<Step1Dto>("Step1");
            var serviceWrappers = TempData.Get<List<ServiceWrapperViewModel>>("ServiceWrappers");
            if (ModelState.IsValid)
            {
                var wrapperDict = new Dictionary<ServiceType, List<ServiceWrapper>>();

                //model.EventTypesSelected.ForEach(x => wrapperDict[(ServiceType)Enum.Parse(typeof(ServiceType), x)] = serviceService.GetServiceWrappersByDateAndNOP(DateTime.Parse(model.EventDate), x,model.Participants));
                return View(new EventPlanningStep2ViewModel());
            }
            return View(new EventPlanningStep2ViewModel()
            {
                Step1 = new Step1Dto().InjectFrom(step1) as Step1Dto,
                ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), step1.EventTypesSelected[0]),
                ServiceSelectedIndex = step1.EventTypesSelected.Count() > 2 ? 1 : 0,
                ServiceWrappers = serviceWrappers,
            });
        }
    }
}
