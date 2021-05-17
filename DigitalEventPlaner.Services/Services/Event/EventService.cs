using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer.Enumerations;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.Event.Dto;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.EventService.Dto;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services;
using Microsoft.Extensions.Configuration;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.Event
{
    public class EventService : IEventService
    {
        private IRepository<DataLayer.Entities.Event> repository;
        private IEventServiceService eventServiceService;
        private IRepository<DataLayer.Entities.Service> serviceRepo;
        private IServicePackageService servicePackageService;
        private IUnitOfWork unit;
        private IConfiguration config;

        public EventService(IRepository<DataLayer.Entities.Event> repository,
            IRepository<DataLayer.Entities.Service> serviceRepo,
            IEventServiceService eventServiceService,
            IServicePackageService servicePackageService,
            IUnitOfWork unit,
            IConfiguration config
            )
        {
            this.repository = repository;
            this.eventServiceService = eventServiceService;
            this.servicePackageService = servicePackageService;
            this.serviceRepo = serviceRepo;
            this.unit = unit;
            this.config = config;
        }

        public int Create(EventDto eventDto)
        {
            if (eventDto == null) throw new ArgumentNullException(nameof(EventDto));
            var newEvent = new DataLayer.Entities.Event().InjectFrom(eventDto) as DataLayer.Entities.Event;
            repository.Add(newEvent);
            unit.Commit();

            return newEvent.Id;
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

        public void Create(EventDto eventDto, Dictionary<int, int> serviceDict)
        {
            List<EventServiceDto> eventServiceList = new List<EventServiceDto>();
            var eventId = Create(eventDto);
            foreach (var key in serviceDict.Keys)
            {
                var serviceId = servicePackageService.GetServiceIdByServicePackageId(serviceDict[key]);

                eventServiceService.Create(new EventServiceDto()
                {
                    EventId = eventId,
                    ServiceId = serviceId,
                    ServicePackageId = serviceDict[key],
                    Status = RequestStatus.Requested
                });
            }
            unit.Commit();
        }

        public void UpdateDoneEvents()
        {
            var events = repository.GetAll().Where(x => x.IsDeleted == false);
            foreach(var eventItem in events)
            {
                if(DateTime.Compare(eventItem.EventDate, DateTime.Today) < 0 && eventItem.Status != EventStatus.Done)
                {
                    if(eventItem.Status != EventStatus.Cancelled)
                    {
                        eventItem.Status = EventStatus.Done;
                    }
                    else
                    {
                        eventItem.Status = EventStatus.Cancelled;
                    }
                    repository.Update(eventItem);
                }
            }
            unit.Commit();
        }

        public void UpdateToBeDoneStatusById(int eventId)
        {
            var eventItem = repository.GetById(eventId);
            eventItem.Status = EventStatus.ToBeDone;
            repository.Update(eventItem);
            unit.Commit();
        }

        public void AcceptAndUpdateEventService(int id)
        {
            var eventServiceItem = eventServiceService.GetById(id);
            eventServiceItem.Status = DataLayer.Enumerations.RequestStatus.Accepted;
            eventServiceService.Update(eventServiceItem);

            var allServices = eventServiceService.GetByEventId(eventServiceItem.EventId);
            var allServicesAccepted = true;
            foreach (var service in allServices)
            {
                if (eventServiceItem.Status != DataLayer.Enumerations.RequestStatus.Accepted)
                {
                    allServicesAccepted = false;
                }
            }
            if (allServicesAccepted) UpdateToBeDoneStatusById(eventServiceItem.EventId);
        }
    }
}
