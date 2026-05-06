using Payroll.Core.DTOs;

namespace Payroll.Core.Interfaces.Services
{
    public interface IOvertimeService
    {
        Task<ProcessResultDto> ProcessFileAsync(Stream file, string filename);
    }
}
