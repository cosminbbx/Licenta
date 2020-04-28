using System;
using DataLayer.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Infrastructure
{
    public static class DataContainer
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
