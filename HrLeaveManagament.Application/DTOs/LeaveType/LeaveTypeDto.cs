using HrLeaveManagament.Application.DTOs.Common;

namespace HrLeaveManagament.Application.DTOs.LeaveType
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
