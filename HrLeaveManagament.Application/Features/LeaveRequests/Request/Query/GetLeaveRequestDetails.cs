using HrLeaveManagament.Application.DTOs.LeaveRequest;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequest.Request.Query
{
    public class GetLeaveRequestDetails : IRequest<List<LeaveRequestListDto>>
    {
    }
}
