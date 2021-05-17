using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.EventService.Dto;

namespace DigitalEventPlaner.Services.Services.EventService
{
    public interface IEventServiceService
    {
        List<EventServiceDto> GetAll();
        List<EventServiceDto> GetByEventId(int id);
        List<EventServiceDto> GetByServiceId(int id);
        List<EventServiceDto> GetByServicePackageId(int id);
        EventServiceDto GetById(int id);
        void Create(EventServiceDto eventService);
        void Update(EventServiceDto eventService);
        void UpdateServicePackage(int eventServiceId, int serviceId, int servicePackageId);
        void Decline(int id);
    }
}
