using System;
using System.Threading;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.CsvService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DigitalEventPlaner.Web.ScheduleServices
{
    public class CsvUpdater : IHostedService
    {
        private readonly ICsvService csvService;

        public CsvUpdater(ICsvService csvService)
        {
            this.csvService = csvService;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await csvService.UpdateCsv(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
