using System;
using System.Threading;
using System.Threading.Tasks;

namespace DigitalEventPlaner.Services.Services.CsvService
{
    public interface ICsvService
    {
        Task UpdateCsv(CancellationToken cancellationToken);
    }
}
