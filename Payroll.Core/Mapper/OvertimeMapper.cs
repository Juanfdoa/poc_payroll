using Payroll.Core.DTOs;
using Payroll.Core.Tables;

namespace Payroll.Core.Mapper
{
    public static class OvertimeMapper
    {
        public static OvertimeRecordTable MapValid(OvertimeDto row)
        {
            return new OvertimeRecordTable
            {
                EmployeeDocument = row.EmployeeDocument!,
                OvertimeType = row.OvertimeType!,
                Hours = decimal.TryParse(row.Hours, out var hours) ? hours : 0,
                ReportDate = DateTime.TryParse(row.ReportDate, out var date) ? date : DateTime.MinValue
            };
        }

        public static OvertimeErrorTable MapError(OvertimeDto row, List<string> errors)
        {
            return new OvertimeErrorTable
            {
                EmployeeDocument = row.EmployeeDocument,
                OvertimeType = row.OvertimeType,
                Hours = row.Hours,
                ReportDate = row.ReportDate,
                ErrorMessage = string.Join(" | ", errors)
            };
        }
    }
}
