using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveRequest.Validators;
using HrLeaveManagament.Application.Features.LeaveRequests.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using HrLeaveManagament.Application.Responses;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveRequests.Handler.Command
{
    internal class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequest, BaseResponse>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private IMapper _mapper;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse> Handle(CreateLeaveRequest request, CancellationToken cancellationToken)
        {
            var baseResponse = new BaseResponse();
            var leaveRequestValidator = new CreateLeaveRequestValidator(_leaveRequestRepository);
            var validationResult = await leaveRequestValidator.ValidateAsync(request.CreateLeaveRequestDto);
            if (validationResult.IsValid)
            {
                var leaveRequest = _mapper.Map<HrLeaveManagement.Domian.LeaveRequest>(request.CreateLeaveRequestDto);
                var result = await _leaveRequestRepository.AddAsync(leaveRequest);

                baseResponse.Success = true;
                baseResponse.Message = "Creation Successfull";
                baseResponse.Id = result.Id;
            }
            else
            {

                baseResponse.Success = false;
                baseResponse.Message = "Creation Failed";
                baseResponse.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            };

            return baseResponse;
        }
    }
}
