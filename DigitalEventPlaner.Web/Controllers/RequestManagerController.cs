using System;
using System.Collections.Generic;
using System.Linq;
using DigitalEventPlaner.Services.Services.Event;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Web.Helpers;
using DigitalEventPlaner.Web.Models.MyEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class RequestManagerController : Controller
    {
        private readonly IServiceService serviceService;
        private readonly IEventServiceService eventServiceService;
        private readonly IEventService eventService;
        public RequestManagerController(IServiceService serviceService, IEventServiceService eventServiceService, IEventService eventService)
        {
            this.serviceService = serviceService;
            this.eventServiceService = eventServiceService;
            this.eventService = eventService;
        }

        [Authorize(Roles = "Service")]
        public IActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var eventRequests = serviceService.GetServiceRequests(userId);

            var viewModelList = GeneralHelper.MapServiceRequestList(eventRequests);
            return View(viewModelList);
        }

        [Authorize(Roles = "Service")]
        public IActionResult Accept(int eventServiceId)
        {
            eventService.AcceptAndUpdateEventService(eventServiceId);
            return RedirectToAction(nameof(RequestManagerController.Index), "RequestManager");
        }

        [Authorize(Roles = "Service")]
        public IActionResult Decline(int eventServiceId)
        {
            eventServiceService.Decline(eventServiceId);
            return RedirectToAction(nameof(RequestManagerController.Index), "RequestManager");
        }
    }
}
