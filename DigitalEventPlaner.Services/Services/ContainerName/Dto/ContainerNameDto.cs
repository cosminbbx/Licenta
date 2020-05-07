using System;
using DataLayer.Enumerations;

namespace DigitalEventPlaner.Services.Services.ContainerName.Dto
{
    public class ContainerNameDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public ContainerType ContainerType { get; set; }
    }
}
