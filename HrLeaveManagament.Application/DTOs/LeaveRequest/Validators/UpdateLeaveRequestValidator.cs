using FluentValidation;
using HrLeaveManagament.Application.Persistance.Contracts;

namespace HrLeaveManagament.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new ILeaveRequestDtoValidator(leaveRequestRepository));
            RuleFor(p => p.Cancelled)
                .NotNull();
        }
    }
}
