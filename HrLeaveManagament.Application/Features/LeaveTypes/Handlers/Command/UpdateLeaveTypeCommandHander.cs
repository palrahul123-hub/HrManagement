using AutoMapper;
using HrLeaveManagament.Application.Features.LeaveTypes.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveTypes.Handlers.Command
{
    public class UpdateLeaveTypeCommandHander : IRequestHandler<UpdateLeaveTypeRequest, Unit>
    {
        protected readonly ILeaveTypeRepository _leaveTypeRepository;
        protected readonly IMapper _mapper;

        public UpdateLeaveTypeCommandHander(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(request.LeaveType.Id);
            _mapper.Map(request.LeaveType, leaveType);
            await _leaveTypeRepository.UpdateAsync(leaveType);
            return Unit.Value;
        }
    }
}
