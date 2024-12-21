using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Request.Query
{
    public class GetLeaveAllocationListRequest : IRequest<LeaveAllocationListDto>
    {
    }
}
