using System;
using System.Collections.Generic;
using System.Security.Claims;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.User;
using DigitalEventPlaner.Web.Infrastructure;
using DigitalEventPlaner.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username,string password)
        {
            var user = userService.Login(username, password);
            if(user != null)
            {
                if(user.UserType == UserType.Customer)
                {
                    //var x = user.UserType.ToString();
                    Authenticate(user.Id,user.UserName, user.Email, user.UserType);
                    var userModel = new UserIdentity();
                    userModel.InjectFrom(user);
                    HttpContext.Session.SetUser(userModel);
                    return RedirectToAction("CustomerProfile");
                }
                else
                {
                    Authenticate(user.Id,user.UserName, user.Email, user.UserType);
                    var userModel = new UserIdentity();
                    userModel.InjectFrom(user);
                    HttpContext.Session.SetUser(userModel);
                    return RedirectToAction("ServiceProfile");
                }
                    
                
            }
            return View();
        }

        [Authorize(Roles = "Customer")]
        public IActionResult CustomerProfile()
        {
            return View();
        }

        [Authorize(Roles = "Service")]
        public IActionResult ServiceProfile()
        {
            return View();
        }

        public void Authenticate(int userId, string username,string email,UserType userType)
        {
            var userClaims = new List<Claim>() {
                new Claim("Id",userId.ToString()),
                new Claim(ClaimTypes.Name,username),
                new Claim(ClaimTypes.Email,email),
                new Claim(ClaimTypes.Role,userType.ToString()),
            };

            var userIdentity = new ClaimsIdentity(userClaims, "User Identity");

            var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });

            HttpContext.SignInAsync(userPrincipal);

            //return RedirectToAction("Index");
        }

        public IActionResult AccessDenied (string ReturnUrl)
        {
            return View();
        }
    }
}
