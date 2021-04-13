using System;
using DigitalEventPlaner.Services.Services.Event.Dto;

namespace DigitalEventPlaner.Services.Services.MLService
{
    public interface IMLService
    {
        public float BugetEstimation(EventDto eventDto);
    }
}
