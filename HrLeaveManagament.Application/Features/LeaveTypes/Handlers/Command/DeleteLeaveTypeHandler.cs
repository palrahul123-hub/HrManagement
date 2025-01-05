using HrLeaveManagament.Application.Exception;
using HrLeaveManagament.Application.Features.LeaveTypes.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using HrLeaveManagament.Application.Responses;
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
            var response = new BaseResponse();
            var lst = await _leaveTypeRepository.GetAsync(request.Id);
            if (lst == null)
            {
                throw new NotFoundException(nameof(HrLeaveManagement.Domian.LeaveType), request);
            }
            else
            {
                await _leaveTypeRepository.DeleteAsync(request.Id);
            }
        }
    }
}
