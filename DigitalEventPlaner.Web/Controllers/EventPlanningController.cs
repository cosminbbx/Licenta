using System;
using System.Linq;
using DataLayer.Enumerations;
using DigitalEventPlaner.Web.Models.EventPlanning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DigitalEventPlaner.Web.Controllers
{
    public class EventPlanningController : Controller
    {
        public EventPlanningController()
        {
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
            return View(model);
        }
    }
}
