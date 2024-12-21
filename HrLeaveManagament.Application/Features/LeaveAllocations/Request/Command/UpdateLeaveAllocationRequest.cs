using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Request.Command
{
    public class UpdateLeaveAllocationRequest : IRequest<Unit>
    {
        public UpdateLeaveAllocationDto? allocationDto { get; set; }
    }
}
