using System;
using System.Collections.Generic;
using DigitalEventPlaner.Services.Services.ContainerName.Dto;

namespace DigitalEventPlaner.Services.Services.ContainerName
{
    public interface IContainerNameService
    {
        List<ContainerNameDto> GetAll();
        List<ContainerNameDto> GetByUserId(int id);
        ContainerNameDto GetById(int id);
        ContainerNameDto GetContainerByUserId(int id);
        ContainerNameDto GetProfilePictureByUserId(int id);
        void Create(ContainerNameDto container);
        void Update(ContainerNameDto container);
        void Delete(int id);
    }
}
