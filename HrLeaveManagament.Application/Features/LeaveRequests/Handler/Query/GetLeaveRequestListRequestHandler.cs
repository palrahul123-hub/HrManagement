using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveRequest;
using HrLeaveManagament.Application.Features.LeaveRequest.Request.Query;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequest.Handler.Query
{
    public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestDetails, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveRequestListRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestDetails request, CancellationToken cancellationToken)
        {
            var lst = await _leaveRequestRepository.GetLeaveRequestList();
            return _mapper.Map<List<LeaveRequestListDto>>(lst);
        }
    }
}
