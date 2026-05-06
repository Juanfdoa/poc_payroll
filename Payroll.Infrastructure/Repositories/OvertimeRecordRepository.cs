using Payroll.Core.Interfaces.Repositories;
using Payroll.Core.Tables;

namespace Payroll.Infrastructure.Repositories
{
    public class OvertimeRecordRepository : BaseRepository<OvertimeRecordTable>, IOvertimeRecordRepository
    {
        public OvertimeRecordRepository(IdentityDbContext context) : base(context) { }
       
    }
}
