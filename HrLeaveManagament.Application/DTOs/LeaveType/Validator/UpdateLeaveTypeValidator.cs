using FluentValidation;

namespace HrLeaveManagament.Application.DTOs.LeaveType.Validator
{
    public class UpdateLeaveTypeValidator : AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDtoValidator());

            RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
