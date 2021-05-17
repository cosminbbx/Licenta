using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Enumerations;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.Event;
using DigitalEventPlaner.Services.Services.Event.Dto;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services.Dto;
using DigitalEventPlaner.Services.Services.User;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.Services
{
    public class ServiceService : IServiceService
    {

        private IRepository<DataLayer.Entities.Service> repository;
        private IServicePackageService servicePackage;
        private IEventService eventService;
        private IEventServiceService eventServiceService;
        private IUserService userService;
        private IUnitOfWork unit;
        public ServiceService(IRepository<DataLayer.Entities.Service> repository, IServicePackageService servicePackage, IEventService eventService, IEventServiceService eventServiceService, IUserService userService, IUnitOfWork unit)
        {
            this.repository = repository;
            this.servicePackage = servicePackage;
            this.eventService = eventService;
            this.eventServiceService = eventServiceService;
            this.userService = userService;
            this.unit = unit;
        }

        public void Create(ServiceDto service)
        {
            if (service == null) throw new ArgumentNullException(nameof(ServiceDto));
            repository.Add(new DataLayer.Entities.Service().InjectFrom(service) as DataLayer.Entities.Service);
            unit.Commit();
        }

        public List<ServiceDto> GetAll()
        {
            var serviceList = repository.GetAll();
            var serviceListDto = new List<ServiceDto>();
            foreach (var service in serviceList)
            {
                serviceListDto.Add(new ServiceDto().InjectFrom(service) as ServiceDto);
            }
            return serviceListDto;
        }

        public ServiceDto GetById(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));
            var service = repository.Query(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            return service == null ? null : new ServiceDto().InjectFrom(service) as ServiceDto;
        }

        public List<ServiceDto> GetByUserId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));
            var serviceList = repository.Query(x => x.UserId == id && x.IsDeleted == false).ToList();
            var serviceListDto = new List<ServiceDto>();
            foreach (var service in serviceList)
            {
                serviceListDto.Add(new ServiceDto().InjectFrom(service) as ServiceDto);
            }
            return serviceListDto;
        }

        public void SoftDelete(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));
            var service = repository.GetById(id);
            service.IsDeleted = true;
            repository.Update(service);
            unit.Commit();
        }

        public void Update(ServiceDto service)
        {
            if (service == null) throw new ArgumentNullException(nameof(ServiceDto));

            var serviceEntity = repository.GetById(service.Id).InjectFrom(service) as DataLayer.Entities.Service;
            if (serviceEntity == null) throw new Exception($"Cannot service user with id = {service.Id}");
            repository.Update(serviceEntity);
            unit.Commit();
        }

        public void AddSmartRating(int id, float smartRate)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));

            var serviceEntity = repository.GetById(id);
            serviceEntity.SmartRate = serviceEntity.SmartRate + smartRate;
            serviceEntity.NumberOfRatings++;
            repository.Update(serviceEntity);
            unit.Commit();
        }

        public List<ServiceDto> GetDeletedByUserId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));
            var serviceList = repository.Query(x => x.UserId == id && x.IsDeleted == true).ToList();
            var serviceListDto = new List<ServiceDto>();
            foreach (var service in serviceList)
            {
                serviceListDto.Add(new ServiceDto().InjectFrom(service) as ServiceDto);
            }
            return serviceListDto;
        }

        public void Undelete(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));

            var service = repository.GetById(id);
            if(service.IsDeleted == true)
            {
                service.IsDeleted = false;
                repository.Update(service);
                unit.Commit();
            }
        }

        public List<ServiceWrapper> GetServiceWrappersByUserId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));

            var serviceList = GetByUserId(id);
            var wrapperList = new List<ServiceWrapper>();
            foreach(var service in serviceList)
            {
                wrapperList.Add(new ServiceWrapper() { Service = service, ServicePackages = servicePackage.GetByServiceId(service.Id) });
            };
            return wrapperList;
        }

        public ServiceWrapper GetServiceWrapperByServiceId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));

            return new ServiceWrapper() { Service = GetById(id), ServicePackages = servicePackage.GetByServiceId(id) };
        }

        public ServiceWrapper GetServiceWrapperByServiceIdAndServicePackageId(int serviceId, int servicePackageId)
        {
            if (serviceId < 1 || servicePackageId < 1) throw new ArgumentNullException(nameof(ServiceDto));

            var servicepackageList = new List<ServicePackage.Dto.ServicePackageDto>();
            servicepackageList.Add(servicePackage.GetById(servicePackageId));

            return new ServiceWrapper() { Service = GetById(serviceId), ServicePackages = servicepackageList };
        }

        private List<int> GetUnavailableServiceIdsForDate(DateTime date)
        {
            var serviceList = new List<int>();
            var dictServices = eventService.GetServicesIdForDate(date);

            foreach(var item in dictServices)
            {
                var service = GetById(item.Key);
                if(service.EventsPerDay <= item.Value)
                {
                    serviceList.Add(service.Id);
                }
            }

            return serviceList;
        }

        private List<ServiceDto> GetServicesByType(ServiceType serviceType)
        {
            var serviceList = repository.Query(x => x.ServiceType == serviceType && x.IsDeleted != true).ToList();
            var serviceListDto = new List<ServiceDto>();
            foreach (var service in serviceList)
            {
                serviceListDto.Add(new ServiceDto().InjectFrom(service) as ServiceDto);
            }
            return serviceListDto;
        }

        private List<ServiceDto> GetServicesByTypeAndNOP(ServiceType serviceType, int numberOfParticipants)
        {
            var services = GetServicesByType(serviceType);
            var servicesList = new List<ServiceDto>();
            foreach(var service in services)
            {
                var servicePackages = servicePackage.GetByServiceId(service.Id);
                bool hasCapacity = false;
                foreach(var serviceP in servicePackages)
                {
                    if(serviceP.MaxCapacity > numberOfParticipants)
                    {
                        hasCapacity = true;
                    }
                }
                if (hasCapacity) servicesList.Add(service);
            }

            return servicesList;
        }

        public List<ServiceWrapper> GetServiceWrappersByDateAndNOP( DateTime dateTime, string serviceType, int numberOfParticipants)
        {
            var type = (ServiceType)Enum.Parse(typeof(ServiceType), serviceType);

            var unavailableServices = GetUnavailableServiceIdsForDate(dateTime);

            var services = GetServicesByTypeAndNOP(type,numberOfParticipants);

            var wrapperList = new List<ServiceWrapper>();

            foreach (var service in services)
            {
                if (!unavailableServices.Contains(service.Id))
                {
                    wrapperList.Add(GetServiceWrapperByServiceId(service.Id));
                }
            }

            return wrapperList;
        }
        public List<EventWrapper> GetEventWrappersByUserId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));

            var events = eventService.GetByUserId(id);

            var eventWrapperList = new List<EventWrapper>();

            foreach(var eventItem in events)
            {
                var eventWrapper = new EventWrapper();
                eventWrapper.EventDate = eventItem.EventDate;
                eventWrapper.EventType = eventItem.EventType;
                eventWrapper.EventStatus = eventItem.Status;
                eventWrapper.ServiceWrappers = new List<ServiceWrapper>();

                var eventServices = eventServiceService.GetByEventId(eventItem.Id);

                foreach(var eventService in eventServices)
                {
                    var serviceWrapper = GetServiceWrapperByServiceIdAndServicePackageId(eventService.ServiceId, eventService.ServicePackageId);
                    serviceWrapper.Status = eventService.Status;
                    serviceWrapper.EventServiceId = eventService.Id;
                    eventWrapper.ServiceWrappers.Add(serviceWrapper);
                }

                eventWrapperList.Add(eventWrapper);
            }

            return eventWrapperList.OrderByDescending(x => x.EventDate).ToList();
        }

        public List<EventRequestDto> GetServiceRequests(int userId)
        {
            var services = GetByUserId(userId);
            var requests = new List<EventRequestDto>();

            foreach(var service in services)
            {
                var eventServices = eventServiceService.GetByServiceId(service.Id);

                foreach(var es in eventServices)
                {
                    var ev = eventService.GetById(es.EventId);

                    var request = new EventRequestDto();
                    request.EventService = es;
                    request.EventType = ev.EventType;
                    request.EventDate = ev.EventDate;

                    var user = userService.GetById(ev.UserId);
                    request.UserFirstName = user.FirstName;
                    request.UserLastName = user.LastName;
                    request.UserPhone = user.Phone;

                    request.ServiceWrapper = GetServiceWrapperByServiceIdAndServicePackageId(es.ServiceId, es.ServicePackageId);
                    request.ServiceWrapper.Status = es.Status;
                    requests.Add(request);
                }
            }

            return requests.OrderByDescending(x => x.EventDate).ToList();
        }
    }
}
