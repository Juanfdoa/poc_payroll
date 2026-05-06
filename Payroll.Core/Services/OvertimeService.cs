using Payroll.Core.DTOs;
using Payroll.Core.Interfaces.Services;
using Payroll.Core.Interfaces.Repositories;
using Payroll.Core.Tables;
using Payroll.Core.Exceptions;
using Payroll.Core.Mapper;

namespace Payroll.Core.Services
{
    public class OvertimeService : IOvertimeService
    {
        private readonly IOvertimeRecordRepository _overtimeRecordRepository;
        private readonly IOvertimeErrorRepository _overtimeErrorRepository;
        private readonly IProcessedFileRepository _processedFileRepository;
        private readonly ICsvService _csvService;
        

        public OvertimeService(
            IOvertimeRecordRepository overtimeRecordRepository, 
            IOvertimeErrorRepository overtimeErrorRepository,
            ICsvService csvService,
            IProcessedFileRepository processedFileRepository)
        {
            _overtimeRecordRepository = overtimeRecordRepository;
            _overtimeErrorRepository = overtimeErrorRepository;
            _processedFileRepository = processedFileRepository;
            _csvService = csvService;
        }

        private readonly string[] _validTypes =
        [
            "HE_DIURNA",
            "HE_NOCTURNA",
            "HE_DOMINICAL",
            "HE_FESTIVA"
        ];

        public async Task<ProcessResultDto> ProcessFileAsync(Stream file, string filename)
        {
            if (file.CanSeek) file.Position = 0;

            var fileHash = await CalculateHashAsync(file);

            if (await _processedFileRepository.AnyAsync(x => x.FileHash == fileHash))
                throw new BusinessException("File already processed.");

            if (file.CanSeek) file.Position = 0;

            var data = await _csvService.ReadCsvAsync(file);

            var validRecords = new List<OvertimeRecordTable>();
            var errorRecords = new List<OvertimeErrorTable>();

            foreach (var row in data)
            {
                var errors = Validate(row);

                if (errors.Any())
                {
                    errorRecords.Add(OvertimeMapper.MapError(row, errors));
                    continue;
                }

                validRecords.Add(OvertimeMapper.MapValid(row));
            }


            if (validRecords.Any())
                await _overtimeRecordRepository.AddRangeAsync(validRecords);

            if (errorRecords.Any())
                await _overtimeErrorRepository.AddRangeAsync(errorRecords);

            await _processedFileRepository.AddAsync(ProcessedFileMaper.MaptoTable(
                filename, fileHash, data.Count, validRecords.Count, errorRecords.Count));
            
            return new ProcessResultDto
            {
                Total = data.Count,
                Success = validRecords.Count,
                Errors = errorRecords.Count
            };
        }

        private List<string> Validate(OvertimeDto row)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(row.EmployeeDocument))
                errors.Add("EmployeeDocument is required");

            if (!decimal.TryParse(row.Hours, out var hours) || hours <= 0)
                errors.Add("Hours must be a number greater than 0");

            if (string.IsNullOrWhiteSpace(row.OvertimeType) ||
                !_validTypes.Contains(row.OvertimeType))
                errors.Add("Invalid overtime type");

            if (!DateTime.TryParse(row.ReportDate, out _))
                errors.Add("Invalid date");

            return errors;
        }

        private async Task<string> CalculateHashAsync(Stream file)
        {
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = await sha.ComputeHashAsync(file);
            return Convert.ToBase64String(bytes);
        }
    }
}
