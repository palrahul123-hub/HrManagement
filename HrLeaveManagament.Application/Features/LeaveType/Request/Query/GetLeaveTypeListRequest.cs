using HrLeaveManagament.Application.DTOs;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Request.Query
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
