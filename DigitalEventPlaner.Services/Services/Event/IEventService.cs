using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.Event.Dto;

namespace DigitalEventPlaner.Services.Services.Event
{
    public interface IEventService
    {
        List<EventDto> GetAll();
        List<EventDto> GetByUserId(int id);
        EventDto GetById(int id);
        int Create(EventDto eventDto);
        void Create(EventDto eventDto, Dictionary<int, int> serviceDict);
        void Update(EventDto eventDto);
        void SoftDelete(int id);
        Dictionary<int, int> GetServicesIdForDate(DateTime date);
        void UpdateDoneEvents();
        void UpdateToBeDoneStatusById(int eventId);
        void AcceptAndUpdateEventService(int id);
    }
}
