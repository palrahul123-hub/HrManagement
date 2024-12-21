using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveType;
using HrLeaveManagament.Application.Features.LeaveType.Request.Query;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Handlers.Query
{
    public class GetLeaveTypeByIdRequestHandler : IRequestHandler<GetLeaveTypeByIdRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeByIdRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAsync(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
