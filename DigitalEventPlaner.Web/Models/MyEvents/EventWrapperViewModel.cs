using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Web.Models.Services;

namespace DigitalEventPlaner.Web.Models.MyEvents
{
    public class EventWrapperViewModel
    {
        public DateTime EventDate { get; set; }
        public EventType EventType { get; set; }
        public List<ServiceWrapperViewModel> ServiceWrappers { get; set; }
    }
}
