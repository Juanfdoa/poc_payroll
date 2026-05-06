using Payroll.Core.Interfaces.Repositories;
using Payroll.Core.Tables;

namespace Payroll.Infrastructure.Repositories
{
    public class OvertimeErrorRepository : BaseRepository<OvertimeErrorTable>, IOvertimeErrorRepository
    {
        public OvertimeErrorRepository(IdentityDbContext context) : base(context) { }
      
    }
}
