using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Services.Services.User.Dto;

namespace DigitalEventPlaner.Services.Services.Event.Dto
{
    public class EventWrapper
    {
        public int EventId { get; set; }
        public DateTime EventDate { get; set; }
        public EventType EventType { get; set; }
        public EventStatus EventStatus { get; set; }  
        public List<ServiceWrapper> ServiceWrappers { get; set; }
    }
}
