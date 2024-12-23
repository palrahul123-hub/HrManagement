using HrLeaveManagament.Application.Persistance.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Repositories;

namespace Persistance
{
    public static class PersistanceConfiguration
    {
        public static IServiceCollection ServicePersistanceServcies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrLeaveManagementDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("LeavemanagementConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            return services;
        }
    }
}
