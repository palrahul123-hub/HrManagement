using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Request.Query
{
    public class GetLeaveAllocationDetailsRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
