using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveRequest;
using HrLeaveManagament.Application.Features.LeaveRequest.Request.Query;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequest.Handler.Query
{
    public class GetLeaveReuestByIdRequestHandler : IRequestHandler<GetLeaveReuestByIdRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;
        public GetLeaveReuestByIdRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveReuestByIdRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestById(request.Id);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
