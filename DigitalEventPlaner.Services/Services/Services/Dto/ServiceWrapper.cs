﻿using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.ServicePackage.Dto;

namespace DigitalEventPlaner.Services.Services.Services.Dto
{
    public class ServiceWrapper
    {
        public ServiceDto Service { get; set; }
        public List<ServicePackageDto> ServicePackages { get; set; }
    }
}
