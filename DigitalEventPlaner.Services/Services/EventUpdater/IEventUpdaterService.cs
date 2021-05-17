using System;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalEventPlaner.Services.Services.EventUpdater
{
    public interface IEventUpdaterService
    {
        Task UpdateEvents(CancellationToken cancellationToken);
    }
}
