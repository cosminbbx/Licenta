using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enumerations;

namespace DigitalEventPlaner.Web.Models.Services
{
    public class ServiceViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public ServiceType ServiceType { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public int EventsPerDay { get; set; }
    }
}
