using System;
using System.Collections.Generic;

namespace DigitalEventPlaner.Services.Services.EventService
{
    public class Step1Dto
    {
        public int UserId { get; set; }
        public string EventDate { get; set; }
        public List<string> EventTypesSelected { get; set; }
        public int Participants { get; set; }
        public float Estimation { get; set; }

    }
}
