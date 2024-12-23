using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveAllocation.Validator;
using HrLeaveManagament.Application.Exception;
using HrLeaveManagament.Application.Features.LeaveAllocations.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using HrLeaveManagement.Domian;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Handler.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationRequest, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocationVal = new CreateLeaveAllocationValidator(_leaveAllocationRepository);
            var validationResult = await leaveAllocationVal.ValidateAsync(request.CreateLeaveAllocationDto);
            if (validationResult.IsValid)
            {

                var input = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);
                var result = await _leaveAllocationRepository.AddAsync(input);
                return result.Id;
            }
            else
                throw new ValidationException(validationResult);
        }
    }
}
