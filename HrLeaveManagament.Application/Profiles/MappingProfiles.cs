using AutoMapper;
using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using HrLeaveManagament.Application.DTOs.LeaveRequest;
using HrLeaveManagament.Application.DTOs.LeaveType;
using HrLeaveManagement.Domian;

namespace HrLeaveManagament.Application.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            CreateMap<LeaveAllocation, LeaveAllocationListDto>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
            CreateMap<LeaveAllocation, CreateLeaveRequestDto>().ReverseMap();
            CreateMap<CreateLeaveRequestDto, LeaveRequest>().ReverseMap();
        }
    }
}
