using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.BlobService;
using DigitalEventPlaner.Services.Services.ContainerName;
using DigitalEventPlaner.Services.Services.ContainerName.Dto;
using DigitalEventPlaner.Services.Services.FaceRecognition;
using DigitalEventPlaner.Services.Services.User;
using DigitalEventPlaner.Web.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Web.Controllers
{
    public class CustomerProfileController : Controller
    {
        private readonly IUserService userService;
        private readonly IBlobService blobService;
        private readonly IContainerNameService containerNameService;
        private readonly IFaceRecognitionService faceRecognitionService;
        public CustomerProfileController(IUserService userService, IBlobService blobService, IContainerNameService containerNameService, IFaceRecognitionService faceRecognitionService)
        {
            this.userService = userService;
            this.blobService = blobService;
            this.containerNameService = containerNameService;
            this.faceRecognitionService = faceRecognitionService;
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Profile(double SmartRating = 0.0)
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var profilePicture = await blobService.GetProfilePicture(userId);
            var user = userService.GetById(userId);
            var model = new ProfileViewModel().InjectFrom(user) as ProfileViewModel;
            model.ProfilePictureUrl = profilePicture;

            if (SmartRating > 0.0)
            {
                ViewData["SmartRate"] = SmartRating;
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> imagelist)
        {
            var userId = Int32.Parse(HttpContext.User.Claims.ToList()[0].Value);
            var imageNames = await UploadSmartRateImages(imagelist, userId);
            var smartRateValue = await faceRecognitionService.GetSmartRateForImages(imageNames);
            return RedirectToAction("Profile", new RouteValueDictionary(
            new { controller = "CustomerProfile", action = "Profile", smartRateValue }));
        }

        private async Task<List<string>> UploadSmartRateImages(List<IFormFile> imagelist, int userId)
        {
            var imageList = new List<string>();
            foreach (var image in imagelist)
            {
                using (var stream = new MemoryStream())
                {
                    await image.CopyToAsync(stream);
                    var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
                    await blobService.UploadSmartRateImage(stream.GetBuffer(), image.FileName, fileName);

                    var smartRatingDto = new ContainerNameDto()
                    {
                        Name = fileName,
                        ContainerType = ContainerType.SmartRateImage,
                        UserId = userId
                    };
                    containerNameService.Create(smartRatingDto);
                    imageList.Add(fileName);
                }
            }
            return imageList;
        }
    }
}
