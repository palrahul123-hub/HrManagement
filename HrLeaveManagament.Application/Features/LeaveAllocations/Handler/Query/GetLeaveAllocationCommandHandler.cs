using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using HrLeaveManagament.Application.Features.LeaveAllocations.Request.Query;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Handler.Query
{
    public class GetLeaveAllocationCommandHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationListDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public GetLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationListDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var lst = await _leaveAllocationRepository.GetLeaveAllocationWithdetsils();
            return _mapper.Map<List<LeaveAllocationListDto>>(lst);
        }
    }
}
