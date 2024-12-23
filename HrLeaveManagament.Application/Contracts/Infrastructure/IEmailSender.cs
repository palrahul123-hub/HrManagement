using HrLeaveManagament.Application.Models;

namespace HrLeaveManagament.Application.Contracts.Infrastructure
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(Email email);
    }
}
