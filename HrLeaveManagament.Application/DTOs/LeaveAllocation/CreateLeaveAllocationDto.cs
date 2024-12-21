namespace HrLeaveManagament.Application.DTOs.LeaveAllocation
{
    public class CreateLeaveAllocationDto
    {
        public int NoOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
