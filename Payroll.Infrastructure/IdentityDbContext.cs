using Microsoft.EntityFrameworkCore;
using Payroll.Core.Tables;

namespace Payroll.Infrastructure
{
    public partial class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options) { }
        
        public DbSet<OvertimeRecordTable> OvertimeRecords { get; set;}
        public DbSet<OvertimeErrorTable> OvertimeErrors { get; set;}
        public DbSet<ProcessedFileTable> ProcessedFiles { get; set;}
    }
}
