using System;
using System.Collections.Generic;
using DataLayer.Infrastructure;

namespace DigitalEventPlaner.Services.Services.Event
{
    public class EventGenerator :IEventGenerator
    {
        private IRepository<DataLayer.Entities.Event> repository;
        private IRepository<DataLayer.Entities.Service> serviceRepo;
        private IRepository<DataLayer.Entities.ServicePackage> servicePackageRepo;
        private IUnitOfWork unit;
        public EventGenerator(IRepository<DataLayer.Entities.Event> repository, IRepository<DataLayer.Entities.ServicePackage> servicePackageRepository, IRepository<DataLayer.Entities.Service> serviceRepo, IUnitOfWork unit)
        {
            this.repository = repository;
            this.serviceRepo = serviceRepo;
            this.servicePackageRepo = servicePackageRepository;
            this.unit = unit;
        }

        public void GenerateEvents(int number)
        {
            Random random = new Random();
            for (var i = 0; i < number; i++)
            {
                var eventEntity = new DataLayer.Entities.Event()
                {
                    UserId = 1,
                    NumberOfServices = random.Next(1, 5),
                    Participants = random.Next(100, 400),
                };

                var buget = 0;

                var list = GetRandomServicesId(eventEntity.NumberOfServices);

                foreach (var item in list)
                {
                    var service = serviceRepo.GetById(item);
                    var servicaPacakge = servicePackageRepo.GetById(item);
                    buget = buget + (servicaPacakge.PricePerParticipant * eventEntity.Participants);
                }

                eventEntity.BugetNeeded = buget;
                repository.Add(eventEntity);
            }
            unit.Commit();
        }
        public List<int> GetRandomServicesId(int numberOfServices)
        {
            var list = new List<int>();
            var random = new Random();
            while (list.Count < numberOfServices)
            {
                var serviceID = random.Next(1, 5);
                if (!list.Contains(serviceID))
                {
                    list.Add(serviceID);
                }
            }
            return list;
        }
    }
}
