using System;
using DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataLayer.Infrastructure
{
    public static class DataContainer
    {
        public static IServiceCollection AddToContainer(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetValue<string>("ConnectionStrings:DigitalEventPlannerConnectionString");
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            return services;
        }
    }
}
