using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }
        public int PricePerPerson { get; set; }
    }
}
