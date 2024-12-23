using HrLeaveManagement.Domian;

namespace HrLeaveManagament.Application.Persistance.Contracts
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<List<LeaveAllocation>> GetLeaveAllocationWithdetsils();
        Task<LeaveAllocation> GetLeaveAllocationWithdetsils(int Id);
    }
}
