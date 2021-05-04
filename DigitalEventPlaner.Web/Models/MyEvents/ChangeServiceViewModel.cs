using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Web.Models.Services;
using DigitalEventPlaner.Web.Models.Validation;

namespace DigitalEventPlaner.Web.Models.MyEvents
{
    public class ChangeServiceViewModel
    {
        public int EventServiceId { get; set; }

        public ServiceType ServiceType { get; set; }

        [ListHasElements(ErrorMessage = "You need to select one type of package.")]
        public List<int> ServicePackageSelected { get; set; }

        public List<ServiceWrapperViewModel> ServiceWrappers { get; set; }
    }
}
