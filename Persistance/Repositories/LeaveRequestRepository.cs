using HrLeaveManagament.Application.Persistance.Contracts;
using HrLeaveManagement.Domian;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HrLeaveManagementDBContext _dbContext;
        public LeaveRequestRepository(HrLeaveManagementDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task ChangeLeaveRequestApproval(LeaveRequest leaveRequest, bool approval)
        {
            leaveRequest.Approved = approval;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestById(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(p => p.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestList()
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .ToListAsync();
            return leaveRequest;
        }
    }
}
