using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public int UserId { get; set; }
        public int NumberOfServices { get; set; }
        public int Participants { get; set; }
        public int BugetNeeded { get; set; }
    }
}
