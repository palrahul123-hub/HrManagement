using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveRequest.Validators;
using HrLeaveManagament.Application.Exception;
using HrLeaveManagament.Application.Features.LeaveRequests.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Handler.Command
{
    public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;
        public UpdateLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequestValidator = new UpdateLeaveRequestValidator(_leaveRequestRepository);
            var validationResult = await leaveRequestValidator.ValidateAsync(request.UpdateLeaveRequestDto);
            if (validationResult.IsValid)
            {
                var leaveRequest = await _leaveRequestRepository.GetAsync(request.Id);
                if (request.UpdateLeaveRequestDto != null)
                {
                    _mapper.Map(request.UpdateLeaveRequestDto, leaveRequest);
                    await _leaveRequestRepository.UpdateAsync(leaveRequest);
                }
                else if (request.UpdateLeaveRequestDto != null)
                {
                    await _leaveRequestRepository.ChangeLeaveRequestApproval(leaveRequest, request.ChangeLeaveRequestApprovalDto.Approved);
                }
                return Unit.Value;
            }
            else throw new ValidationException(validationResult);

        }
    }
}
