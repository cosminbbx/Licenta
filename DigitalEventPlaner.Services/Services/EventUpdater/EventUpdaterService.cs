using System;
using System.Threading;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.Event;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalEventPlaner.Services.Services.EventUpdater
{
    public class EventUpdaterService : IEventUpdaterService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IConfiguration config;

        public EventUpdaterService(IConfiguration config, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.config = config;
        }

        public async Task UpdateEvents(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var eventService = scope.ServiceProvider.GetService<IEventService>();
                    eventService.UpdateDoneEvents();
                }
                var numberOfSeconds = config.GetValue<int>("ScheduleService:NumberOfSeconds");
                await Task.Delay(1000 * numberOfSeconds);
            }
        }
    }
}
