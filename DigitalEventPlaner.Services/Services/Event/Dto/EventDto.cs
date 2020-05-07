using System;
using DataLayer.Enumerations;

namespace DigitalEventPlaner.Services.Services.Event.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public EventType EventType { get; set; }
        public int NumberOfServices { get; set; }
        public int Participants { get; set; }
        public int BugetNeeded { get; set; }
        public EventStatus Status { get; set; }
        public DateTime EventDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
