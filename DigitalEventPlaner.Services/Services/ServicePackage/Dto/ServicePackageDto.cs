using System;
namespace DigitalEventPlaner.Services.Services.ServicePackage.Dto
{
    public class ServicePackageDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int PricePerParticipant { get; set; }
        public string Description { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
