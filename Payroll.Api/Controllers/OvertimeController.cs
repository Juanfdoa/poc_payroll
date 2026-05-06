using Microsoft.AspNetCore.Mvc;
using Payroll.Core.DTOs;
using Payroll.Core.Exceptions;
using Payroll.Core.Interfaces.Services;

namespace Payroll.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OvertimeController : ControllerBase
    {
        private readonly IOvertimeService _overtimeService;

        public OvertimeController(IOvertimeService overtimeService)
        {
            _overtimeService = overtimeService;
        }

        [HttpPost("upload")]
        [ProducesResponseType(typeof(ProcessResultDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status409Conflict)]
        public async Task<IActionResult> UploadCsv(IFormFile file,CancellationToken ct)
        {
            try
            {
                if (file == null || file.Length == 0)
                    return BadRequest("No file provided");

                if (!file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                    return BadRequest("File must be a CSV");

                using var stream = file.OpenReadStream();
                var result = await _overtimeService.ProcessFileAsync(stream, file.FileName);

                return Ok(result);
            }
            catch (BusinessException ex)
            {
                return Conflict(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    { "file", new[] { ex.Message } }
                }));
            }
        }
    }
}
