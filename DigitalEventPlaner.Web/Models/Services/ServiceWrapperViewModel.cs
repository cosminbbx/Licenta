﻿using System;
using System.Collections.Generic;
using DigitalEventPlaner.Web.Models.ServicePackage;

namespace DigitalEventPlaner.Web.Models.Services
{
    public class ServiceWrapperViewModel
    {
        public ServiceViewModel Service { get; set; }
        public List<ServicePackageViewModel> ServicePackages { get; set; }
    }
}