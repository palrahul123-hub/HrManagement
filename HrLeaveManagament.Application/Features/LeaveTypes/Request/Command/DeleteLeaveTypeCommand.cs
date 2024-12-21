using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveTypes.Request.Command
{
    public class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
