using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveAllocation.Validator;
using HrLeaveManagament.Application.Exception;
using HrLeaveManagament.Application.Features.LeaveAllocations.Request.Command;
using HrLeaveManagament.Application.Persistance.Contracts;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveAllocations.Handler.Command
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationRequest, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocValidator = new UpdateLeaveAllocationValidator(_leaveAllocationRepository);
            var validationResult = await leaveAllocValidator.ValidateAsync(request.allocationDto);
            if (validationResult.IsValid)
            {
                var leaveAllocation = await _leaveAllocationRepository.GetAsync(request.allocationDto.Id);
                _mapper.Map(request.allocationDto, leaveAllocation);
                await _leaveAllocationRepository.UpdateAsync(leaveAllocation);
                return Unit.Value;
            }
            else
                throw new ValidationException(validationResult);

        }
    }
}
