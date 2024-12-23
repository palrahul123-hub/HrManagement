using FluentValidation;
using HrLeaveManagament.Application.Persistance.Contracts;

namespace HrLeaveManagament.Application.DTOs.LeaveRequest.Validators
{
    public class ILeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public ILeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate).WithMessage("{PropertyName} must before {ComparisonValue}");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate).WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(p => p.LeaveTypeId)
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await _leaveRequestRepository.ExistsAsync(id);
                    return !leaveTypeExists;

                }).WithMessage("{PropertyName} does not exists.");
        }
    }
}
