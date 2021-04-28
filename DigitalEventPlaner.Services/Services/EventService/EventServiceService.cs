using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.EventService.Dto;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.EventService
{
    public class EventServiceService : IEventServiceService
    {
        private IRepository<DataLayer.Entities.EventService> repository;
        private IUnitOfWork unit;
        public EventServiceService(IRepository<DataLayer.Entities.EventService> repository, IUnitOfWork unit)
        {
            this.repository = repository;
            this.unit = unit;
        }

        public void Create(EventServiceDto eventService)
        {
            if (eventService == null) throw new ArgumentNullException(nameof(EventServiceDto));
            repository.Add(new DataLayer.Entities.EventService().InjectFrom(eventService) as DataLayer.Entities.EventService);
            unit.Commit();
        }

        public List<EventServiceDto> GetAll()
        {
            var eventServiceList = repository.GetAll();
            var eventServiceListDto = new List<EventServiceDto>();
            foreach (var eventService in eventServiceList)
            {
                eventServiceListDto.Add(new EventServiceDto().InjectFrom(eventService) as EventServiceDto);
            }
            return eventServiceListDto;
        }

        public List<EventServiceDto> GetByEventId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(EventServiceDto));
            var eventServiceList = repository.Query(x => x.EventId == id).ToList();
            var eventServiceListDto = new List<EventServiceDto>();
            foreach (var eventService in eventServiceList)
            {
                eventServiceListDto.Add(new EventServiceDto().InjectFrom(eventService) as EventServiceDto);
            }
            return eventServiceListDto;
        }

        public EventServiceDto GetById(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(EventServiceDto));
            var eventService = repository.Query(x => x.Id == id).FirstOrDefault();
            return eventService == null ? null : new EventServiceDto().InjectFrom(eventService) as EventServiceDto;
        }

        public List<EventServiceDto> GetByServiceId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(EventServiceDto));
            var eventServiceList = repository.Query(x => x.ServiceId == id).ToList();
            var eventServiceListDto = new List<EventServiceDto>();
            foreach (var eventService in eventServiceList)
            {
                eventServiceListDto.Add(new EventServiceDto().InjectFrom(eventService) as EventServiceDto);
            }
            return eventServiceListDto;
        }

        public List<EventServiceDto> GetByServicePackageId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(EventServiceDto));
            var eventServiceList = repository.Query(x => x.ServicePackageId == id).ToList();
            var eventServiceListDto = new List<EventServiceDto>();
            foreach (var eventService in eventServiceList)
            {
                eventServiceListDto.Add(new EventServiceDto().InjectFrom(eventService) as EventServiceDto);
            }
            return eventServiceListDto;
        }

        public void Update(EventServiceDto eventService)
        {
            if (eventService == null) throw new ArgumentNullException(nameof(EventServiceDto));

            var eventServiceEntity = repository.GetById(eventService.Id).InjectFrom(eventService) as DataLayer.Entities.EventService;
            if (eventServiceEntity == null) throw new Exception($"Cannot update eventService package with id = {eventService.Id}");
            repository.Update(eventServiceEntity);
            unit.Commit();
        }
    }
}
