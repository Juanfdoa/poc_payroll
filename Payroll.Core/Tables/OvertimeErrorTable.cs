using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll.Core.Tables
{
    [Table("overtime_errors")]
    public class OvertimeErrorTable
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("employee_document")]
        public string? EmployeeDocument { get; set; }

        [Column("overtime_type")]
        public string? OvertimeType { get; set; }

        [Column("hours")]
        public string? Hours { get; set; }

        [Column("report_date")]
        public string? ReportDate { get; set; }

        [Column("error_message")]
        public string ErrorMessage { get; set; } = null!;

        [Column("processed_at")]
        public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;
    }
}
