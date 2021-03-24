using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enumerations;

namespace DigitalEventPlaner.Web.Models.Services
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public ServiceType ServiceType { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int EventsPerDay { get; set; }
    }
}
