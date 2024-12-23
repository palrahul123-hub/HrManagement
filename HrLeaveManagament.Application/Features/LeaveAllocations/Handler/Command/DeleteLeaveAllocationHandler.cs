using HrLeaveManagament.Application.Exception;
using HrLeaveManagament.Application.Features.LeaveAllocations.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Handler.Command
{
    public class DeleteLeaveAllocationHandler : IRequestHandler<DeleteLeaveAllocationCommand>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public DeleteLeaveAllocationHandler(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var lst = await _leaveAllocationRepository.ExistsAsync(request.Id);
            if (lst == null)
                throw new NotFoundException(nameof(HrLeaveManagement.Domian.LeaveAllocation), request);
            await _leaveAllocationRepository.DeleteAsync(request.Id);
        }
    }
}
