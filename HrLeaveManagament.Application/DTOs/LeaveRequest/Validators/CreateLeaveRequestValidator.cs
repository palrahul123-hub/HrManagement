using FluentValidation;
using HrLeaveManagament.Application.Persistance.Contracts;

namespace HrLeaveManagament.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public CreateLeaveRequestValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            Include(new ILeaveRequestDtoValidator(_leaveRequestRepository));
        }
    }
}
