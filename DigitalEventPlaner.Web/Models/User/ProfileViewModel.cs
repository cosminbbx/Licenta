﻿using System;
using System.Collections.Generic;

namespace DigitalEventPlaner.Web.Models.User
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
