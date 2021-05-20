using System;
using DataLayer.Enumerations;

namespace DigitalEventPlaner.Services.Services.Services.Dto
{
    public class ServiceDto
    {
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
