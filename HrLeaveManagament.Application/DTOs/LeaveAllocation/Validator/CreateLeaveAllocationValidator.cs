using FluentValidation;
using HrLeaveManagament.Application.Persistance.Contracts;

namespace HrLeaveManagament.Application.DTOs.LeaveAllocation.Validator
{
    public class CreateLeaveAllocationValidator : AbstractValidator<CreateLeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public CreateLeaveAllocationValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            Include(new ILeaveAllocationValidator(_leaveAllocationRepository));
        }
    }
}
