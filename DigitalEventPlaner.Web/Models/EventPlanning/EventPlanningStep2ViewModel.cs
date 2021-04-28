using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Web.Models.Services;
using DigitalEventPlaner.Web.Models.Validation;

namespace DigitalEventPlaner.Web.Models.EventPlanning
{
    public class EventPlanningStep2ViewModel
    {
        public Step1Dto Step1 { get; set; }

        public Dictionary<int,int> ServicePackageMap { get; set; }

        public int ServiceSelectedIndex { get; set; }

        public ServiceType ServiceType { get; set; }

        [ListHasElements(ErrorMessage = "You need to select one type of package.")]
        public List<int> ServicePackageSelected { get; set; }

        public List<ServiceWrapperViewModel> ServiceWrappers { get; set; }

        public int BugetNeeded { get; set; }
    }
}
