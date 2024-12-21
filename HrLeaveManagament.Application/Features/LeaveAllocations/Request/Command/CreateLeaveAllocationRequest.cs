using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Request.Command
{
    public class CreateLeaveAllocationRequest : IRequest<int>
    {
        public CreateLeaveAllocationDto? CreateLeaveAllocationDto { get; set; }
    }
}
