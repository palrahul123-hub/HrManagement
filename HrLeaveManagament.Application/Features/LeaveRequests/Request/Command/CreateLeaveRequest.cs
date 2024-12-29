using HrLeaveManagament.Application.DTOs.LeaveRequest;
using HrLeaveManagament.Application.Responses;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Request.Command
{
    public class CreateLeaveRequest : IRequest<BaseResponse>
    {
        public CreateLeaveRequestDto? createLeaveRequestDto { get; set; }
    }
}
