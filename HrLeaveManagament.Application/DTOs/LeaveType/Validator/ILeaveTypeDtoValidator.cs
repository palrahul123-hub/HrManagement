using FluentValidation;

namespace HrLeaveManagament.Application.DTOs.LeaveType.Validator
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} id required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} should not exeed 50 Characters");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{PropertyName} id required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be atleast 1.")
                .LessThan(100).WithMessage("{PropertyName} must be less than 100.");
        }
    }
}
