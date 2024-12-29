using HrLeaveManagament.Application.DTOs.LeaveType;

namespace HrLeaveManagament.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationListDto
    {
        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
