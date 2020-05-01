using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class EventService
    {
        [Key]
        public int EventServicesId { get; set; }
        public int UserId { get; set; }
        public int ServiceId { get; set; }
    }
}
