using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Web.Models.ServicePackage;
using DigitalEventPlaner.Web.Models.User;

namespace DigitalEventPlaner.Web.Models.Services
{
    public class ServiceWrapperViewModel
    {
        public ServiceViewModel Service { get; set; }
        public List<ServicePackageViewModel> ServicePackages { get; set; }
        public UserViewModel User { get; set; }
        public string ProfilePictureUri { get; set; }
        public RequestStatus Status { get; set; }
        public int EventServiceId { get; set; }
    }
}
