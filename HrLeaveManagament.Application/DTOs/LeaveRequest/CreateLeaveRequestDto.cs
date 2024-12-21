﻿using HrLeaveManagament.Application.DTOs.Common;

namespace HrLeaveManagament.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDto : BaseDto
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string RequestComments { get; set; }
    }
}
