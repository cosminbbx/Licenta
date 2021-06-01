using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.BlobService;
using DigitalEventPlaner.Services.Services.User;
using DigitalEventPlaner.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class ServiceProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IBlobService blobService;
        public ServiceProfileController(IBlobService blobService, IUserService userService)
        {
            this.blobService = blobService;
            this.userService = userService;
        }

        [Authorize(Roles = "Service")]
        public async Task<IActionResult> Profile()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var profilePicture = await blobService.GetProfilePicture(userId);
            var user = userService.GetById(userId);
            var model = new ProfileViewModel().InjectFrom(user) as ProfileViewModel;
            model.ProfilePictureUrl = profilePicture;
            return View(model);
        }

        public async void GetProfilePictureUri()
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var profilePicture = await blobService.GetProfilePicture(userId);
            ViewData["ProfilePicture"] = profilePicture.First();
        }
    }
}
