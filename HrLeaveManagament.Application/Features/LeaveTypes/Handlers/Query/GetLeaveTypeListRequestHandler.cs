using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveType;
using HrLeaveManagament.Application.Features.LeaveType.Request.Query;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Handlers.Query
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var lst = await _leaveTypeRepository.GetAllAsync();
            return _mapper.Map<List<LeaveTypeDto>>(lst);
        }
    }
}
