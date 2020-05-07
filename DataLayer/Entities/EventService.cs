using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enumerations;

namespace DataLayer.Entities
{
    public class EventService
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public int ServiceId { get; set; }
        public int ServicePackageId { get; set; }
        public RequestStatus Status { get; set; }
    }
}
