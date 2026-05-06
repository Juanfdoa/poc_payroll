using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll.Core.Tables
{
    [Table("overtime_records")]
    public class OvertimeRecordTable
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("employee_document")]
        public string EmployeeDocument { get; set; } = null!;

        [Column("overtime_type")]
        public string OvertimeType { get; set; } = null!;

        [Column("hours")]
        public decimal Hours { get; set; }

        [Column("report_date")]
        public DateTime ReportDate { get; set; }

        [Column("processed_at")]
        public DateTime ProcessedAt { get; set; } = DateTime.UtcNow;

        [Column("validation_status")]
        public string ValidationStatus { get; set; } = "SUCCESS";
    }
}
