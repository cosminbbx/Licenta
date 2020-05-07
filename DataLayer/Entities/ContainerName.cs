using System;
using System.ComponentModel.DataAnnotations;
using DataLayer.Enumerations;

namespace DataLayer.Entities
{
    public class ContainerName
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public ContainerType ContainerType { get; set; }
    }
}
