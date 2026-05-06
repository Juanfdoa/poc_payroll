using Payroll.Core.DTOs;
using Payroll.Core.Interfaces.Services;

namespace Payroll.Core.Services
{
    public class CsvService : ICsvService
    {
        public async Task<List<OvertimeDto>> ReadCsvAsync(Stream file)
        {
            var result = new List<OvertimeDto>();

            using var reader = new StreamReader(file);

            var headerLine = await reader.ReadLineAsync();

            while (!reader.EndOfStream)
            {
                var line = await reader.ReadLineAsync();

                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var values = line.Split(',')
                                 .Select(x => x.Trim())
                                 .ToArray();

                if (values.Length < 4)
                    continue;

                result.Add(new OvertimeDto
                {
                    EmployeeDocument = values[0],
                    OvertimeType = values[1],     
                    Hours = values[2],            
                    ReportDate = values[3]     
                });
            }

            return result;
        }
    }
}
