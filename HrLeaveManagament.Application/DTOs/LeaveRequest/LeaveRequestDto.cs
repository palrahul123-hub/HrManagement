using HrLeaveManagament.Application.DTOs.Common;
using HrLeaveManagament.Application.DTOs.LeaveType;

namespace HrLeaveManagament.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
