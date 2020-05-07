using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string ResourceArea { get; set; }
        public string ResourceKey { get; set; }
        public string ResourceValue { get; set; }
    }
}
