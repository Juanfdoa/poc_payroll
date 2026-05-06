using Payroll.Core.DTOs;

namespace Payroll.Core.Interfaces.Services
{
    public interface ICsvService
    {
        Task<List<OvertimeDto>> ReadCsvAsync(Stream file);
    }
}
