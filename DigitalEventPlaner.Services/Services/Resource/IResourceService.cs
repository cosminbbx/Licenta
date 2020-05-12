using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.Resource.Dto;

namespace DigitalEventPlaner.Services.Services.Resource
{
    public interface IResourceService
    {
        List<ResourceDto> GetAll();
        string GetByAreaAndKeyId(string area, string key);
        ResourceDto GetById(int id);
        void Create(ResourceDto resource);
        void Update(ResourceDto service);
    }
}
