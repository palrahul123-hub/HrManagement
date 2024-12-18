using HrLeaveManagament.Application.DTOs.Common;

namespace HrLeaveManagament.Application.DTOs
{
    public class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
