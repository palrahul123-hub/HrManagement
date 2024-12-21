using AutoMapper;
using HrLeaveManagament.Application.Features.LeaveRequests.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Handler.Command
{
    internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequest, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<HrLeaveManagement.Domian.LeaveRequest>(request.CreateLeaveRequestDto);
            var result = await _leaveRequestRepository.AddAsync(leaveRequest);
            return result.Id;
        }
    }
}
