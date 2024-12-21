using HrLeaveManagament.Application.DTOs.LeaveRequest;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Request.Command
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public UpdateLeaveRequestDto? UpdateLeaveRequestDto { get; set; }
        public ChangeLeaveRequestApprovalDto ChangeLeaveRequestApprovalDto { get; set; }
    }
}
