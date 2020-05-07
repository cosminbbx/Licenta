using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class ServicePackage
    {
        [Key]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int PricePerParticipant { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
