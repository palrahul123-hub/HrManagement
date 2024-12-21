using HrLeaveManagament.Application.DTOs.LeaveRequest;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequest.Request.Query
{
    public class GetLeaveAllocationListRequest : IRequest<List<LeaveRequestListDto>>
    {
    }
}
