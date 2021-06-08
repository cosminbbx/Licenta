using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.ServicePackage.Dto;
using DigitalEventPlaner.Services.Services.User.Dto;

namespace DigitalEventPlaner.Services.Services.Services.Dto
{
    public class ServiceWrapper
    {
        public ServiceDto Service { get; set; }
        public UserDto User { get; set; }
        public List<ServicePackageDto> ServicePackages { get; set; }
        public RequestStatus Status { get; set; }
        public string ProfilePictureUri { get; set; }
        public int EventServiceId { get; set; }
    }
}
