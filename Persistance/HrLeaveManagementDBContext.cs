using HrLeaveManagement.Domian;
using HrLeaveManagement.Domian.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class HrLeaveManagementDBContext : DbContext
    {
        public HrLeaveManagementDBContext(DbContextOptions<HrLeaveManagementDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagementDBContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.UtcNow;
                if (entry.State == EntityState.Added)
                    entry.Entity.DateCreated = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
