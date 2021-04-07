using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DigitalEventPlaner.Services.Services.Event;
using DigitalEventPlaner.Services.Services.Event.Dto;
using DigitalEventPlaner.Services.Services.Services;
using DigitalEventPlaner.Services.Services.Services.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalEventPlaner.Services.Services.CsvService
{
    public class CsvService : ICsvService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IConfiguration config;

        public CsvService(IConfiguration config, IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.config = config;
        }

        public async Task UpdateCsv(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                GenerateCsv();
                var numberOfSeconds = config.GetValue<int>("ScheduleService:NumberOfSeconds");
                await Task.Delay(1000 * numberOfSeconds);
            }
        }

        private void GenerateCsv()
        {
            var trainPath = Path.Combine(config.GetValue<string>("CsvPath:Train"), "event-train.csv");
            var testPath = Path.Combine(config.GetValue<string>("CsvPath:Test"), "event-test.csv");

            var header = "UserId,NumberOfServices,Participants,BugetNeeded" + Environment.NewLine;

            var csvTrain = new StringBuilder();
            var csvTest = new StringBuilder();

            csvTrain.Append(header);
            csvTest.Append(header);

            List<EventDto> eventList;

            using (var scope = serviceProvider.CreateScope())
            {
                var eventService = scope.ServiceProvider.GetService<IEventService>();
                eventList = eventService.GetAll();
            }

            for (var i = 0; i <= (eventList.Count / 2) - 1; i++)
            {
                var eventLine = eventList[i];
                var line = eventLine.UserId.ToString() + "," +
                           eventLine.NumberOfServices.ToString() + "," +
                           eventLine.Participants.ToString() + "," +
                           eventLine.BugetNeeded.ToString() +
                           Environment.NewLine;
                csvTrain.Append(line);
            }

            for (var i = (eventList.Count / 2); i <= eventList.Count - 1; i++)
            {
                var eventLine = eventList[i];
                var line = eventLine.UserId.ToString() + "," +
                           eventLine.NumberOfServices.ToString() + "," +
                           eventLine.Participants.ToString() + "," +
                           eventLine.BugetNeeded.ToString() +
                           Environment.NewLine;
                csvTest.Append(line);
            }
            using (var stream = File.CreateText(trainPath))
            {
                stream.WriteLine(csvTrain);
            }
            using (var stream = File.CreateText(testPath))
            {
                stream.WriteLine(csvTest);
            }
        }
    }
}
