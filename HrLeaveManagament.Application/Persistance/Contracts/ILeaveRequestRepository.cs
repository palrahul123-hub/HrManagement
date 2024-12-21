using HrLeaveManagement.Domian;

namespace HrLeaveManagament.Application.Persistance.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<List<LeaveRequest>> GetLeaveRequestList();
        Task<LeaveRequest> GetLeaveRequestById(int id);
    }
}
