using HrLeaveManagament.Application.DTOs;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Request.Command
{
    public class CreateLeaveTypeRequest : IRequest<int>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; };
    }
}
