using AutoMapper;
using HrLeaveManagament.Application.Features.LeaveType.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Handlers.Command
{
    public class CreateLeaveTypeRequestHandler : IRequestHandler<CreateLeaveTypeRequest, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveType = _mapper.Map<HrLeaveManagement.Domian.LeaveType>(request.LeaveTypeDto);
            var result = await _leaveTypeRepository.AddAsync(leaveType);
            return result.Id;
        }


    }
}
