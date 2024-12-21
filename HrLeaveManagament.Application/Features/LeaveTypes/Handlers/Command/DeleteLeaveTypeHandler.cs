using HrLeaveManagament.Application.Features.LeaveTypes.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveTypes.Handlers.Command
{
    public class DeleteLeaveTypeHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
        protected readonly ILeaveTypeRepository _leaveTypeRepository;
        public DeleteLeaveTypeHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            await _leaveTypeRepository.DeleteAsync(request.Id);
        }
    }
}
