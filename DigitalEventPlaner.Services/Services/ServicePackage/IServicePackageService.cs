using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.ServicePackage.Dto;

namespace DigitalEventPlaner.Services.Services.ServicePackage
{
    public interface IServicePackageService
    {
        List<ServicePackageDto> GetAll();
        List<ServicePackageDto> GetByServiceId(int id);
        ServicePackageDto GetById(int id);
        void Create(ServicePackageDto servicePackage);
        void Update(ServicePackageDto servicePackage);
        void SoftDelete(int id);
    }
}
