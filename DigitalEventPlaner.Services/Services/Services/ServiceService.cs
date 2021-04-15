using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Enumerations;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.Event;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services.Dto;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.Services
{
    public class ServiceService : IServiceService
    {

        private IRepository<DataLayer.Entities.Service> repository;
        private IServicePackageService servicePackage;
        private IEventService eventService;
        private IUnitOfWork unit;
        public ServiceService(IRepository<DataLayer.Entities.Service> repository, IServicePackageService servicePackage, IEventService eventService, IUnitOfWork unit)
        {
            this.repository = repository;
            this.servicePackage = servicePackage;
            this.eventService = eventService;
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
                foreach(var serviceP in servicePackages)
                {
                    if(serviceP.MaxCapacity > numberOfParticipants)
                    {
                        servicesList.Add(service);
                    }
                }
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
    }
}
