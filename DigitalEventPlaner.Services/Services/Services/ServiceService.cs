using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.Services.Dto;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.Services
{
    public class ServiceService : IServiceService
    {

        private IRepository<DataLayer.Entities.Service> repository;
        private IUnitOfWork unit;
        public ServiceService(IRepository<DataLayer.Entities.Service> repository, IUnitOfWork unit)
        {
            this.repository = repository;
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
            var service = repository.Query(x => x.Id == id).FirstOrDefault();
            return service == null ? null : new ServiceDto().InjectFrom(service) as ServiceDto;
        }

        public List<ServiceDto> GetByUserId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServiceDto));
            var serviceList = repository.Query(x => x.UserId == id).ToList();
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
    }
}
