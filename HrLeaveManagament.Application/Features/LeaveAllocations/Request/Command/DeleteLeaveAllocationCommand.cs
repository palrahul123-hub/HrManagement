using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Request.Command
{
    public class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
