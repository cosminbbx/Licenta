using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.BlobService;
using DigitalEventPlaner.Services.Services.ContainerName;
using DigitalEventPlaner.Services.Services.ContainerName.Dto;
using DigitalEventPlaner.Services.Services.User;
using DigitalEventPlaner.Services.Services.User.Dto;
using DigitalEventPlaner.Web.Infrastructure;
using DigitalEventPlaner.Web.Models;
using DigitalEventPlaner.Web.Models.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IBlobService blobService;
        private readonly IContainerNameService containerNameService;
        public AccountController(IUserService userService, IBlobService blobService, IContainerNameService containerNameService)
        {
            this.userService = userService;
            this.blobService = blobService;
            this.containerNameService = containerNameService;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Profile()
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
        public async Task<IActionResult> CustomerProfile()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var profilePicture = await blobService.GetProfilePicture(userId);
            ViewBag.Url = profilePicture;
            return View(profilePicture);
        }

        [Authorize(Roles = "Service")]
        public IActionResult ServiceProfile()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var profilePicture = blobService.GetProfilePicture(userId);
            ViewBag.Url = profilePicture;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public JsonResult VerifyUserName(string UserName)
        {
            if (userService.GetByUsername(UserName) != null)
            {
                return new JsonResult($"A user named {UserName} already exists." );
            }

            return new JsonResult(true );
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto().InjectFrom(model) as UserDto;
                userDto.DateCreated = DateTime.Now;
                userDto.IsDeleted = false;

                userService.Create(userDto);

                var user = userService.GetByUsername(userDto.UserName);

                var containerGuid = Guid.NewGuid();
                var profilePictureGuid = Guid.NewGuid();
                var comtainerDto = new ContainerNameDto()
                {
                    Name = containerGuid.ToString(),
                    ContainerType = ContainerType.Container,
                    UserId = user.Id
                };
                var profilePictureDto = new ContainerNameDto()
                {
                    Name = profilePictureGuid.ToString() + Path.GetExtension(model.ProfilePicture[0].FileName),
                    ContainerType = ContainerType.ProfilePicture,
                    UserId = user.Id
                };
                containerNameService.Create(comtainerDto);
                containerNameService.Create(profilePictureDto);

                await UploadProfilePicture(model.ProfilePicture, containerGuid.ToString(), profilePictureGuid.ToString() + Path.GetExtension(model.ProfilePicture[0].FileName));

                return RedirectToAction("Login");
            }
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

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.ClearUserSession();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private async Task<IActionResult> UploadProfilePicture(List<IFormFile> imagelist,string containerGuid, string profilePictureGuid)
        {
            var tasklist = new List<Task<string>>();
            foreach (var image in imagelist)
            {
                using (var stream = new MemoryStream())
                {
                    await image.CopyToAsync(stream);
                    tasklist.Add(blobService.UploadInNewContainer(stream.GetBuffer(), image.FileName, containerGuid, profilePictureGuid));
                }
            }
            await Task.WhenAll(tasklist);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult AccessDenied (string ReturnUrl)
        {
            return View();
        }
    }
}
