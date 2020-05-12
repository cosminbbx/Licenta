using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.Resource.Dto;
using Omu.ValueInjecter;

namespace DigitalEventPlaner.Services.Services.Resource
{
    public class ResourceService : IResourceService
    {
        private IRepository<DataLayer.Entities.Resource> repository;
        private IUnitOfWork unit;
        public ResourceService(IRepository<DataLayer.Entities.Resource> repository, IUnitOfWork unit)
        {
            this.repository = repository;
            this.unit = unit;
        }

        public void Create(ResourceDto resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(ResourceDto));
            repository.Add(new DataLayer.Entities.Resource().InjectFrom(resource) as DataLayer.Entities.Resource);
            unit.Commit();
        }

        public List<ResourceDto> GetAll()
        {
            var resourceList = repository.GetAll();
            var resourceListDto = new List<ResourceDto>();
            foreach (var resource in resourceList)
            {
                resourceListDto.Add(new ResourceDto().InjectFrom(resource) as ResourceDto);
            }
            return resourceListDto;
        }

        public string GetByAreaAndKeyId(string area, string key)
        {
            if (string.IsNullOrEmpty(area) || string.IsNullOrEmpty(key)) return null;
            var resource = repository.Query(x => x.ResourceArea == area && x.ResourceKey == key).FirstOrDefault();
            return resource.ResourceValue;
        }

        public ResourceDto GetById(int id)
        {
            if (id < 1) throw new ArgumentNullException(nameof(ResourceDto));
            var resource = repository.Query(x => x.Id == id).FirstOrDefault();
            return resource == null ? null : new ResourceDto().InjectFrom(resource) as ResourceDto;
        }

        public void Update(ResourceDto resource)
        {
            if (resource == null) throw new ArgumentNullException(nameof(ResourceDto));

            var resourceEntity = repository.GetById(resource.Id).InjectFrom(resource) as DataLayer.Entities.Resource;
            if (resourceEntity == null) throw new Exception($"Cannot update resource with id = {resource.Id}");
            repository.Update(resourceEntity);
            unit.Commit();
        }
    }
}
