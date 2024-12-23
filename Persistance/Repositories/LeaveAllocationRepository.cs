using HrLeaveManagament.Application.Persistance.Contracts;
using HrLeaveManagement.Domian;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly HrLeaveManagementDBContext _dbContext;
        public LeaveAllocationRepository(HrLeaveManagementDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithdetsils()
        {
            var leaveAllocation = await _dbContext.LeaveAllocations.Include(p => p.LeaveType).ToListAsync();
            return leaveAllocation;
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithdetsils(int Id)
        {
            var leaveAllocation = await _dbContext.LeaveAllocations
                .Include(p => p.LeaveType).FirstOrDefaultAsync(p => p.Id == Id);
            return leaveAllocation;
        }
    }
}
