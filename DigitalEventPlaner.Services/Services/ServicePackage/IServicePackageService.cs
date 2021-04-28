using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.ServicePackage.Dto;
using DigitalEventPlaner.Services.Services.Services.Dto;

namespace DigitalEventPlaner.Services.Services.ServicePackage
{
    public interface IServicePackageService
    {
        List<ServicePackageDto> GetAll();
        List<ServicePackageDto> GetByServiceId(int id);
        int GetServiceIdByServicePackageId(int id);
        ServicePackageDto GetById(int id);
        void Create(ServicePackageDto servicePackage);
        void Update(ServicePackageDto servicePackage);
        void SoftDelete(int id);
    }
}
