using System;
using System.Collections.Generic;
using DataLayer.Enumerations;
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
        void Undelete(int id);
        List<ServiceDto> GetDeletedByUserId(int id);
        List<ServiceWrapper> GetServiceWrappersByUserId(int id);
        ServiceWrapper GetServiceWrapperByServiceId(int id);
        List<ServiceWrapper> GetServiceWrappersByDateAndNOP(DateTime dateTime, string serviceType, int numberOfParticipants);
    }
}
