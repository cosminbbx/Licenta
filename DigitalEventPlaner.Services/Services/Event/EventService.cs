using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.Event.Dto;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.Services;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.Event
{
    public class EventService : IEventService
    {
        private IRepository<DataLayer.Entities.Event> repository;
        private IEventServiceService eventServiceService;
        private IUnitOfWork unit;
        public EventService(IRepository<DataLayer.Entities.Event> repository, IEventServiceService eventServiceService, IUnitOfWork unit)
        {
            this.repository = repository;
            this.eventServiceService = eventServiceService;
            this.unit = unit;
        }

        public void Create(EventDto eventDto)
        {
            if (eventDto == null) throw new ArgumentNullException(nameof(EventDto));
            repository.Add(new DataLayer.Entities.Event().InjectFrom(eventDto) as DataLayer.Entities.Event);
            unit.Commit();
        }

        public List<EventDto> GetAll()
        {
            var eventList = repository.GetAll().Where(x => x.IsDeleted == false);
            var eventListDto = new List<EventDto>();
            foreach (var eventItem in eventList)
            {
                eventListDto.Add(new EventDto().InjectFrom(eventItem) as EventDto);
            }
            return eventListDto;
        }

        public EventDto GetById(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(EventDto));
            var eventEntity = repository.Query(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            return eventEntity == null ? null : new EventDto().InjectFrom(eventEntity) as EventDto;
        }

        public List<EventDto> GetByUserId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(EventDto));
            var eventList = repository.Query(x => x.UserId == id && x.IsDeleted == false).ToList();
            var eventListDto = new List<EventDto>();
            foreach (var eventService in eventList)
            {
                eventListDto.Add(new EventDto().InjectFrom(eventService) as EventDto);
            }
            return eventListDto;
        }

        public void SoftDelete(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(EventDto));
            var eventItem = repository.GetById(id);
            eventItem.IsDeleted = true;
            repository.Update(eventItem);
            unit.Commit();
        }

        public void Update(EventDto eventDto)
        {
            if (eventDto == null) throw new ArgumentNullException(nameof(EventDto));

            var eventEntity = repository.GetById(eventDto.Id).InjectFrom(eventDto) as DataLayer.Entities.Event;
            if (eventEntity == null) throw new Exception($"Cannot event user with id = {eventDto.Id}");
            repository.Update(eventEntity);
            unit.Commit();
        }

        public Dictionary<int, int> GetServicesIdForDate(DateTime date)
        {
            Dictionary<int,int> serviceDict = new Dictionary<int, int>();
            var events = repository.Query(x => x.EventDate == date).ToList();

            foreach(var eventItem in events)
            {
                var eventServices = eventServiceService.GetByEventId(eventItem.Id);
                foreach(var eventService in eventServices)
                {
                    int currentCount;
                    serviceDict.TryGetValue(eventService.ServiceId, out currentCount);
                    serviceDict[eventService.ServiceId] = currentCount + 1;
                }
            }

            return serviceDict;
        }
    }
}
