using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Request.Command
{
    public class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
