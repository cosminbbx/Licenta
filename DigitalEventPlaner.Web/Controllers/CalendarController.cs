using System;
using System.Linq;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalEventPlaner.Web.Controllers
{
    public class CalendarController : Controller
    {
        private readonly IServiceService serviceService;
        public CalendarController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [Authorize(Roles = "Service")]
        public IActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var eventRequests = serviceService.GetCalendar(userId);

            var viewModelList = GeneralHelper.MapServiceRequestList(eventRequests);
            return View(viewModelList);
        }

        [Authorize(Roles = "Customer")]
        public IActionResult CustomerCalendar()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var eventRequests = serviceService.GetCustomerCalendar(userId);

            var viewModelList = GeneralHelper.MapServiceRequestList(eventRequests);
            return View(viewModelList);
        }
    }
}
