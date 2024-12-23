using HrLeaveManagament.Application.Exception;
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
            var lst = await _leaveRequestRepository.ExistsAsync(request.Id);
            if (lst == null)
                throw new NotFoundException(nameof(HrLeaveManagement.Domian.LeaveRequest), request);
            await _leaveRequestRepository.DeleteAsync(request.Id);
        }
    }
}
