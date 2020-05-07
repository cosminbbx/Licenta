using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enumerations;

namespace DataLayer.Entities
{
    public class Event
    {
        [Key]
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
