using System;
using DataLayer.Enumerations;

namespace DigitalEventPlaner.Services.Services.EventService.Dto
{
    public class EventServiceDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ServiceId { get; set; }
        public int ServicePackageId { get; set; }
        public RequestStatus Status { get; set; }
    }
}
