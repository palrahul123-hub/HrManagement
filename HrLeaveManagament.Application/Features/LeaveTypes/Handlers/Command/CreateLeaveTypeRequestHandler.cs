using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveType.Validator;
using HrLeaveManagament.Application.Features.LeaveType.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using HrLeaveManagament.Application.Responses;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Handlers.Command
{
    public class CreateLeaveTypeRequestHandler : IRequestHandler<CreateLeaveTypeRequest, BaseResponse>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse();
            var leaveTypeValidator = new CreateLeaveTypeDtoValidator();
            var validationResult = await leaveTypeValidator.ValidateAsync(request.createLeave);
            if (validationResult.IsValid)
            {
                var leaveType = _mapper.Map<HrLeaveManagement.Domian.LeaveType>(request.createLeave);
                var result = await _leaveTypeRepository.AddAsync(leaveType);

                response.Success = true;
                response.Message = "Creation Successfull";
                response.Id = leaveType.Id;

            }
            else
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }

            return response;
        }
    }
}
