using System;
using System.Collections.Generic;
using System.Linq;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Web.Helpers;
using DigitalEventPlaner.Web.Models.MyEvents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class MyEventsController : Controller
    {
        private readonly IServiceService serviceService;
        private readonly IServicePackageService servicePackageService;
        public MyEventsController(IServiceService serviceService, IServicePackageService servicePackageService)
        {
            this.serviceService = serviceService;
            this.servicePackageService = servicePackageService;
        }

        [Authorize(Roles = "Customer")]
        public IActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var eventWrappers = serviceService.GetEventWrappersByUserId(userId);

            var viewModelList = GeneralHelper.MapEventWrapperList(eventWrappers);
            return View(viewModelList);
        }
    }
}
