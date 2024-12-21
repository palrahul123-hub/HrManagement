using HrLeaveManagament.Application.DTOs.LeaveRequest;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Request.Command
{
    public class CreateLeaveRequest : IRequest<int>
    {
        public CreateLeaveRequestDto? CreateLeaveRequestDto { get; set; }
    }
}
