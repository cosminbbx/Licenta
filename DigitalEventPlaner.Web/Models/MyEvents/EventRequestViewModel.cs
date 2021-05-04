using System;
using DataLayer.Enumerations;
using DigitalEventPlaner.Web.Models.Services;

namespace DigitalEventPlaner.Web.Models.MyEvents
{
    public class EventRequestViewModel
    {
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserPhone { get; set; }
        public EventType EventType { get; set; }

        public EventServiceViewModel EventService { get; set; }
        public ServiceWrapperViewModel ServiceWrapper { get; set; }
    }
}
