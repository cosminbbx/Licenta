using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Services.Services.Services.Dto;
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
        public ServiceManageController(IServiceService serviceService)
        {
            this.serviceService = serviceService;
        }

        [Authorize(Roles = "Service")]
        public IActionResult Index()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var serviceDtoList = serviceService.GetByUserId(userId);
            var serviceViewModelList = new List<ServiceViewModel>();
            foreach(var service in serviceDtoList)
            {
                serviceViewModelList.Add(new ServiceViewModel().InjectFrom(service) as ServiceViewModel);
            }
            return View(serviceViewModelList);
        }

        [Authorize(Roles = "Service")]
        [HttpGet]
        public IActionResult AddService()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var model = new ServiceViewModel() { UserId = userId };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddService(ServiceViewModel model)
        {
            serviceService.Create(new ServiceDto().InjectFrom(model) as ServiceDto);
            return RedirectToAction(nameof(ServiceManageController.Index), "ServiceManage");
        }
    }
}
