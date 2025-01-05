using HrLeaveManagament.Application.DTOs.LeaveType;
using HrLeaveManagament.Application.Responses;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Request.Command
{
    public class CreateLeaveTypeRequest : IRequest<BaseResponse>
    {
        public CreateLeaveTypeDto? createLeave { get; set; }
    }
}
