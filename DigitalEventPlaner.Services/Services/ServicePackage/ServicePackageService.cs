using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.ServicePackage.Dto;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.ServicePackage
{
    public class ServicePackageService : IServicePackageService
    {
        private IRepository<DataLayer.Entities.ServicePackage> repository;
        private IUnitOfWork unit;
        public ServicePackageService(IRepository<DataLayer.Entities.ServicePackage> repository, IUnitOfWork unit)
        {
            this.repository = repository;
            this.unit = unit;
        }

        public void Create(ServicePackageDto service)
        {
            if (service == null) throw new ArgumentNullException(nameof(ServicePackageDto));
            repository.Add(new DataLayer.Entities.ServicePackage().InjectFrom(service) as DataLayer.Entities.ServicePackage);
            unit.Commit();
        }

        public List<ServicePackageDto> GetAll()
        {
            var serviceList = repository.GetAll();
            var serviceListDto = new List<ServicePackageDto>();
            foreach (var service in serviceList)
            {
                serviceListDto.Add(new ServicePackageDto().InjectFrom(service) as ServicePackageDto);
            }
            return serviceListDto;
        }

        public ServicePackageDto GetById(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServicePackageDto));
            var service = repository.Query(x => x.Id == id).FirstOrDefault();
            return service == null ? null : new ServicePackageDto().InjectFrom(service) as ServicePackageDto;
        }

        public List<ServicePackageDto> GetByServiceId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServicePackageDto));
            var serviceList = repository.Query(x => x.ServiceId == id).ToList();
            var serviceListDto = new List<ServicePackageDto>();
            foreach (var service in serviceList)
            {
                serviceListDto.Add(new ServicePackageDto().InjectFrom(service) as ServicePackageDto);
            }
            return serviceListDto;
        }

        public void SoftDelete(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ServicePackageDto));
            var service = repository.GetById(id);
            service.IsDeleted = true;
            repository.Update(service);
            unit.Commit();
        }

        public void Update(ServicePackageDto service)
        {
            if (service == null) throw new ArgumentNullException(nameof(ServicePackageDto));

            var serviceEntity = repository.GetById(service.Id).InjectFrom(service) as DataLayer.Entities.ServicePackage;
            if (serviceEntity == null) throw new Exception($"Cannot update service package with id = {service.Id}");
            repository.Update(serviceEntity);
            unit.Commit();
        }
    }
}
