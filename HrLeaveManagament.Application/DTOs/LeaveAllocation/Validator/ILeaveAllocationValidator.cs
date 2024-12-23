using FluentValidation;
using HrLeaveManagament.Application.Persistance.Contracts;

namespace HrLeaveManagament.Application.DTOs.LeaveAllocation.Validator
{
    public class ILeaveAllocationValidator : AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public ILeaveAllocationValidator(ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;

            RuleFor(p => p.NumberOfDays)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .GreaterThan(0).WithMessage("{PropertyName} should atleast grater than 0.");

            RuleFor(p => p.LeaveTypeId)
                .NotNull()
            .MustAsync(async (id, token) =>
            {
                var leaveAllocation = await _leaveAllocationRepository.ExistsAsync(id);
                return leaveAllocation;
            }).WithMessage("{PropertyName} does not exists.")
                .GreaterThan(0).WithMessage("Please Select atleast one leavetype");

            RuleFor(p => p.Period)
                .NotEmpty().WithMessage("{PropertyName} is Required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} should be greater than 0.")
                .LessThan(100).WithMessage("{PropertyName} should be less than 100.");
        }
    }
}
