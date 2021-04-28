using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.Services.Dto;

namespace DigitalEventPlaner.Services.Services.Event.Dto
{
    public class EventWrapper
    {
        public DateTime EventDate { get; set; }
        public EventType EventType { get; set; }
        public List<ServiceWrapper> ServiceWrappers { get; set; }
    }
}
