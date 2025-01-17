﻿using HrLeaveManagament.Application.DTOs.LeaveType;
using MediatR;

namespace HrLeaveManagament.Application.Features.LeaveType.Request.Query
{
    public class GetLeaveTypeByIdRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
