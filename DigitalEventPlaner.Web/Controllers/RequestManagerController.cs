using System;
using System.Collections.Generic;
using System.Linq;
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
        public RequestManagerController(IServiceService serviceService, IEventServiceService eventServiceService)
        {
            this.serviceService = serviceService;
            this.eventServiceService = eventServiceService;
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
            eventServiceService.Accept(eventServiceId);
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
