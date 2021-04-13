using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using DataLayer.Enumerations;

namespace DigitalEventPlaner.Web.Models.EventPlanning
{
    public class EventPlanningStep1ViewModel
    {
        public int UserId { get; set; }
        [Required]
        public string EventDate { get; set; }
        [Required]
        public List<string> EventTypes { get; set; }

        [Required]
        public List<string> EventTypesSelected { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Participants { get; set; }

        public string StringDateNow { get; set; }

        public float Estimation { get; set; }

        public EventPlanningStep1ViewModel()
        {
            EventTypes = Enum.GetNames(typeof(ServiceType)).ToList();
            StringDateNow = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
    