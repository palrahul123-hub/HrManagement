using HrLeaveManagament.Application.Persistance.Contracts;
using HrLeaveManagement.Domian;

namespace Persistance.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HrLeaveManagementDBContext _dbContext;
        public LeaveTypeRepository(HrLeaveManagementDBContext dbContext) : base(dbContext)
        {

        }
    }
}
