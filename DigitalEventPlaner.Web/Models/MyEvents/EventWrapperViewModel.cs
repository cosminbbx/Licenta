using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Web.Models.Services;
using DigitalEventPlaner.Web.Models.User;

namespace DigitalEventPlaner.Web.Models.MyEvents
{
    public class EventWrapperViewModel
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public EventType EventType { get; set; }
        public EventStatus EventStatus { get; set; }
        public List<Services.ServiceWrapperViewModel> ServiceWrappers { get; set; }
    }
}
