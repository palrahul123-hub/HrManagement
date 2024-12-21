using HrLeaveManagament.Application.DTOs.LeaveType;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveTypes.Request.Command
{
    public class UpdateLeaveTypeRequest : IRequest<Unit>
    {
        public LeaveTypeDto? LeaveType { get; set; }
    }
}
