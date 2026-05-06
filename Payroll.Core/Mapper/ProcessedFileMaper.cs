using Payroll.Core.Tables;

namespace Payroll.Core.Mapper
{
    public static class ProcessedFileMaper
    {
        public static ProcessedFileTable MaptoTable(string filename, string fileHash, int totalRecords, int successRecords, int errorRecords)
        {
            return new ProcessedFileTable
            {
                FileName = filename,
                FileHash = fileHash,
                TotalRecords = totalRecords,
                SuccessRecords = successRecords,
                ErrorRecords = errorRecords,
                Status = "Processed",
                CreatedAt = DateTime.UtcNow,
            };
        }
    }
}
