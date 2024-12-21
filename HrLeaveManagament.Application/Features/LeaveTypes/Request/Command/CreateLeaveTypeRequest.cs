using HrLeaveManagament.Application.DTOs.LeaveType;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Request.Command
{
    public class CreateLeaveTypeRequest : IRequest<int>
    {
        public CreateLeaveTypeDto? createLeave { get; set; }
    }
}
