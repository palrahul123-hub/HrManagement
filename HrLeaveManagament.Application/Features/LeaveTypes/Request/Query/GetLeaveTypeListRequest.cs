using HrLeaveManagament.Application.DTOs.LeaveType;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Request.Query
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
