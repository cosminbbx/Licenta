using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DigitalEventPlaner.Web.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using DigitalEventPlaner.Web.Infrastructure;
using DigitalEventPlaner.Services.Services.User;

namespace DigitalEventPlaner.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger,IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
                if (userService.GetById(userId).UserType == DataLayer.Enumerations.UserType.Customer)
                {
                    return RedirectToAction(nameof(AccountController.CustomerProfile), "Account");
                }
                if (userService.GetById(userId).UserType == DataLayer.Enumerations.UserType.Service)
                {
                    return RedirectToAction(nameof(AccountController.ServiceProfile), "Account");
                }
                return View();
            }
            else return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
