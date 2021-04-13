using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.MLService;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Web.Models.EventPlanning;
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
            model.Estimation = mLService.BugetEstimation(new Services.Services.Event.Dto.EventDto()
            {
                UserId = model.UserId,
                NumberOfServices = model.EventTypesSelected.Count(),
                Participants = model.Participants
            });
            //var viewModel = new EventPlanningStep2ViewModel() { Estimation = estimation, Step1 = new Step1Dto().InjectFrom(model) as Step1Dto };
            return RedirectToAction(nameof(EventPlanningController.Step2), "EventPlanning", model);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Step2(EventPlanningStep1ViewModel model)
        {
            var wrapperDict = new Dictionary<ServiceType, List<ServiceWrapper>>();
            model.EventTypesSelected.ForEach(x => wrapperDict[(ServiceType)Enum.Parse(typeof(ServiceType), x)] = serviceService.GetServiceWrappersByDate(DateTime.Parse(model.EventDate), x));
            return View(new EventPlanningStep2ViewModel() { Step1 = new Step1Dto().InjectFrom(model) as Step1Dto });
        }
    }
}
