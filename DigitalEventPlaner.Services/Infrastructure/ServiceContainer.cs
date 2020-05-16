using System;
using System.ComponentModel.Design;
using DataLayer.Infrastructure;
using DigitalEventPlaner.Services.Services.BlobService;
using DigitalEventPlaner.Services.Services.ContainerName;
using DigitalEventPlaner.Services.Services.Event;
using DigitalEventPlaner.Services.Services.EventService;
using DigitalEventPlaner.Services.Services.Resource;
using DigitalEventPlaner.Services.Services.ServicePackage;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Services.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalEventPlaner.Services.Infrastructure
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services,IConfiguration configuration)
        {
            DataContainer.AddToContainer(services, configuration);

            services.AddTransient(typeof(IUserService), typeof(UserService));
            services.AddTransient(typeof(IServiceService), typeof(ServiceService));
            services.AddTransient(typeof(IServicePackageService), typeof(ServicePackageService));
            services.AddTransient(typeof(Services.Resource.IResourceService), typeof(ResourceService));
            services.AddTransient(typeof(IEventServiceService), typeof(EventServiceService));
            services.AddTransient(typeof(IEventService), typeof(EventService));
            services.AddTransient(typeof(IContainerNameService), typeof(ContainerNameService));
            services.AddTransient(typeof(IBlobService), typeof(BlobService));
            return services;
        }
    }
}
