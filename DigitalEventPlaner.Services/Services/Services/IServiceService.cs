using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.Services.Dto;

namespace DigitalEventPlaner.Services.Services.Services
{
    public interface IServiceService
    {
        List<ServiceDto> GetAll();
        List<ServiceDto> GetByUserId(int id);
        ServiceDto GetById(int id);
        void Create(ServiceDto service);
        void Update(ServiceDto service);
        void AddSmartRating(int id, float smartRate);
        void SoftDelete(int id);
    }
}
