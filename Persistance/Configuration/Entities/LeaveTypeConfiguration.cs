using HrLeaveManagement.Domian;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrLeaveManagement.Persistance.Configuration.Entities
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
    {
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
            builder.HasData(new LeaveType()
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Vacation",
                CreatedBy = "Rahul Pal",
                DateCreated = DateTime.Now,
                LastModifiedBy = "Rahul Pal",
                LastModifiedDate = DateTime.Now,
            }, new LeaveType()
            {
                Id = 2,
                DefaultDays = 12,
                Name = "Sick",
                CreatedBy = "Devi Pal",
                DateCreated = DateTime.Now,
                LastModifiedBy = "Devi Pal",
                LastModifiedDate = DateTime.Now,
            });
        }
    }
}
