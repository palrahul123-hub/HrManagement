using HrLeaveManagament.Application.DTOs.LeaveRequest;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequest.Request.Query
{
    public class GetLeaveReuestByIdRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
