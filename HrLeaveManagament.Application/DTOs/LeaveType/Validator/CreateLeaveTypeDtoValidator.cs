using FluentValidation;

namespace HrLeaveManagament.Application.DTOs.LeaveType.Validator
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
