using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveType.Validator;
using HrLeaveManagament.Application.Exception;
using HrLeaveManagament.Application.Features.LeaveType.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Handlers.Command
{
    public class CreateLeaveTypeRequestHandler : IRequestHandler<CreateLeaveTypeRequest, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveTypeRequest request, CancellationToken cancellationToken)
        {
            var leaveTypeValidator = new CreateLeaveTypeDtoValidator();
            var validationResult = await leaveTypeValidator.ValidateAsync(request.createLeave);
            if (validationResult.IsValid)
            {
                var leaveType = _mapper.Map<HrLeaveManagement.Domian.LeaveType>(request.createLeave);
                var result = await _leaveTypeRepository.AddAsync(leaveType);
                return result.Id;
            }
            else
                throw new ValidationException(validationResult);
        }


    }
}
