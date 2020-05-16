using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enumerations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalEventPlaner.Web.Models.User
{
    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public UserType UserType { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public List<IFormFile> ProfilePicture { get; set; }
    }
}
