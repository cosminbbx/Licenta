using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.ContainerName.Dto;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.ContainerName
{
    public class ContainerNameService : IContainerNameService
    {
        private IRepository<DataLayer.Entities.ContainerName> repository;
        private IUnitOfWork unit;
        public ContainerNameService(IRepository<DataLayer.Entities.ContainerName> repository, IUnitOfWork unit)
        {
            this.repository = repository;
            this.unit = unit;
        }

        public void Create(ContainerNameDto container)
        {
            if (container == null) throw new ArgumentNullException(nameof(ContainerNameDto));
            repository.Add(new DataLayer.Entities.ContainerName().InjectFrom(container) as DataLayer.Entities.ContainerName);
            unit.Commit();
        }

        public void Delete(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ContainerNameDto));
            var container = repository.GetById(id);
            repository.Delete(container);
        }

        public List<ContainerNameDto> GetAll()
        {
            var containerList = repository.GetAll();
            var containerListDto = new List<ContainerNameDto>();
            foreach (var eventItem in containerList)
            {
                containerListDto.Add(new ContainerNameDto().InjectFrom(eventItem) as ContainerNameDto);
            }
            return containerListDto;
        }

        public ContainerNameDto GetContainerByUserId(int id)
        {
            var containerNameEntity = repository.Query(x => x.UserId == id && x.ContainerType == DataLayer.Enumerations.ContainerType.Container).FirstOrDefault();
            return new ContainerNameDto().InjectFrom(containerNameEntity) as ContainerNameDto;
        }
        public ContainerNameDto GetProfilePictureByUserId(int id)
        {
            var containerNameEntity = repository.Query(x => x.UserId == id && x.ContainerType == DataLayer.Enumerations.ContainerType.ProfilePicture).FirstOrDefault();
            return new ContainerNameDto().InjectFrom(containerNameEntity) as ContainerNameDto;
        }

        public ContainerNameDto GetById(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ContainerNameDto));
            var container = repository.Query(x => x.Id == id).FirstOrDefault();
            return container == null ? null : new ContainerNameDto().InjectFrom(container) as ContainerNameDto;
        }

        public List<ContainerNameDto> GetByUserId(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ContainerNameDto));
            var containerList = repository.Query(x => x.UserId == id).ToList();
            var containerListDto = new List<ContainerNameDto>();
            foreach (var container in containerList)
            {
                containerListDto.Add(new ContainerNameDto().InjectFrom(container) as ContainerNameDto);
            }
            return containerListDto;
        }

        public void Update(ContainerNameDto container)
        {
            if (container == null) throw new ArgumentNullException(nameof(ContainerNameDto));

            var containerEntity = repository.GetById(container.Id).InjectFrom(container) as DataLayer.Entities.ContainerName;
            if (containerEntity == null) throw new Exception($"Cannot container user with id = {container.Id}");
            repository.Update(containerEntity);
            unit.Commit();
        }
    }
}
