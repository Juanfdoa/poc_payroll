using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payroll.Core.Tables
{
    [Table("processed_files")]
    public class ProcessedFileTable
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("file_name")]
        public string FileName { get; set; } = null!;

        [Column("file_hash")]
        public string FileHash { get; set; } = null!;

        [Column("total_records")]
        public int TotalRecords { get; set; }

        [Column("success_records")]
        public int SuccessRecords { get; set; }

        [Column("error_records")]
        public int ErrorRecords { get; set; }

        [Column("status")]
        public string Status { get; set; } = null!;

        [Column("storage_url")]
        public string? Storage_url { get; set; } = null!;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
