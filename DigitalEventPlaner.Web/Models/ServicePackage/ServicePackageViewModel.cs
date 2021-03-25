using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalEventPlaner.Web.Models.ServicePackage
{
    public class ServicePackageViewModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        [Required]
        [Range(1, 5000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int PricePerParticipant { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaxCapacity { get; set; }
    }
}
