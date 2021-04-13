using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.Event.Dto;

namespace DigitalEventPlaner.Services.Services.Event
{
    public interface IEventService
    {
        List<EventDto> GetAll();
        List<EventDto> GetByUserId(int id);
        EventDto GetById(int id);
        void Create(EventDto eventDto);
        void Update(EventDto eventDto);
        void SoftDelete(int id);
        Dictionary<int, int> GetServicesIdForDate(DateTime date);
    }
}
