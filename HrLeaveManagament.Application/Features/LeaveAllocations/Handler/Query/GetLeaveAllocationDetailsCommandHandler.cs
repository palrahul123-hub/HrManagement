using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using HrLeaveManagament.Application.Features.LeaveAllocations.Request.Query;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Handler.Query
{
    public class GetLeaveAllocationDetailsCommandHandler : IRequestHandler<GetLeaveAllocationDetailsRequest, LeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public GetLeaveAllocationDetailsCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailsRequest request, CancellationToken cancellationToken)
        {
            var lst = await _leaveAllocationRepository.GetAsync(request.Id);
            return _mapper.Map<LeaveAllocationDto>(lst);
        }
    }
}
