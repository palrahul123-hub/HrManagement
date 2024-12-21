using HrLeaveManagament.Application.Features.LeaveRequests.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Handler.Command
{
    public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        protected readonly ILeaveRequestRepository _leaveRequestRepository;
        public DeleteLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            await _leaveRequestRepository.DeleteAsync(request.Id);
        }
    }
}
