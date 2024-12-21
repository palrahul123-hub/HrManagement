using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HrLeaveManagament.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(options =>
            {

                options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            });
            //services.AddAutoMapper(typeof(MappingProfiles));

            return services;
        }
    }
}
