using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Enumerations
{
    public enum UserType
    {
        [Display(Name = "Customer")]
        Customer = 1,
        [Display(Name = "Service")]
        Service = 2
    }
}
