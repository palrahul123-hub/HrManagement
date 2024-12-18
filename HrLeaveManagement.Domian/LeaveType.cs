using HrLeaveManagement.Domian.Common;

namespace HrLeaveManagement.Domian
{
    public class LeaveType : BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
