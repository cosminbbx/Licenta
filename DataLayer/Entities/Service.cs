using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enumerations;

namespace DataLayer.Entities
{
    public class Service
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public ServiceType ServiceType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EventsPerDay { get; set; }
        public double SmartRate { get; set; }
        public int NumberOfRatings { get; set; }
        public bool IsDeleted { get; set; }
    }
}
