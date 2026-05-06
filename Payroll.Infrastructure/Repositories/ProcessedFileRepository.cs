using Payroll.Core.Interfaces.Repositories;
using Payroll.Core.Tables;

namespace Payroll.Infrastructure.Repositories
{
    public class ProcessedFileRepository : BaseRepository<ProcessedFileTable>, IProcessedFileRepository
    {
        public ProcessedFileRepository(IdentityDbContext context) : base(context) { }
    }
}
