using HrLeaveManagament.Application.Contracts.Infrastructure;
using HrLeaveManagament.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HrLeaveManagement.Insfrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        private EmailSettings _settings { get; }

        public EmailSender(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }
        public async Task<bool> SendEmail(Email email)
        {
            var sendGridClient = new SendGridClient(_settings.APIKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress()
            {
                Email = _settings.FromAddress,
                Name = _settings.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await sendGridClient.SendEmailAsync(message);

            return response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;
        }
    }
}
