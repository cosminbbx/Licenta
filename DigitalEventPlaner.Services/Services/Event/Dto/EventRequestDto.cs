using System;
using DataLayer.Enumerations;
using DigitalEventPlaner.Services.Services.EventService.Dto;
using DigitalEventPlaner.Services.Services.Services.Dto;

namespace DigitalEventPlaner.Services.Services.Event.Dto
{
    public class EventRequestDto
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public EventType EventType { get; set; }
        public DateTime EventDate { get; set; }
        public EventServiceDto EventService { get; set; }

        public ServiceWrapper ServiceWrapper { get; set; }
    }
}
