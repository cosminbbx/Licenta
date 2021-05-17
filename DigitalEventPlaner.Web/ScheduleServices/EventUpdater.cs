using System;
using System.Threading;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.Event;
using DigitalEventPlaner.Services.Services.EventUpdater;
using Microsoft.Extensions.Hosting;

namespace DigitalEventPlaner.Web.ScheduleServices
{
    public class EventUpdater : IHostedService
    {
        private readonly IEventUpdaterService eventService;

        public EventUpdater(IEventUpdaterService eventService)
        {
            this.eventService = eventService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            eventService.UpdateEvents(cancellationToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
