using HrLeaveManagament.Application.Contracts.Infrastructure;
using HrLeaveManagament.Application.Models;
using HrLeaveManagement.Insfrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HrLeaveManagement.Insfrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection InfaServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings").Bind);
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
