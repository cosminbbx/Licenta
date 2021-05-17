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
        public EventStatus EventStatus { get; set; }
        public List<Services.ServiceWrapperViewModel> ServiceWrappers { get; set; }
    }
}
