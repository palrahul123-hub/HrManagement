using HrLeaveManagament.Application.DTOs.LeaveRequest;
using HrLeaveManagament.Application.Features.LeaveRequest.Request.Query;
using HrLeaveManagament.Application.Features.LeaveRequests.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveRequestController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveRequests = await _mediator.Send(new GetLeaveRequestDetails());
            return Ok(leaveRequests);
        }

        // GET api/<LeaveRequestController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaveRequest = await _mediator.Send(new GetLeaveReuestByIdRequest { Id = id });
            return Ok(leaveRequest);
        }

        // POST api/<LeaveRequestController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveRequestDto createLeaveRequestDto)
        {
            var leaveRequest = await _mediator.Send(new CreateLeaveRequest { createLeaveRequestDto = createLeaveRequestDto });
            return Ok(leaveRequest);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateLeaveRequestDto updateLeaveRequestDto)
        {
            var leaveRequest = await _mediator.Send(new UpdateLeaveRequestCommand { UpdateLeaveRequestDto = updateLeaveRequestDto, Id = id });
            return Ok(leaveRequest);
        }

        // PUT api/<LeaveRequestController>/5
        [HttpPut("ChangeApproval/{id}")]
        public async Task<IActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto changeLeaveRequestApprovalDto)
        {
            var leaveRequest = await _mediator.Send(new UpdateLeaveRequestCommand { ChangeLeaveRequestApprovalDto = changeLeaveRequestApprovalDto, Id = id });
            return Ok(leaveRequest);
        }

        // DELETE api/<LeaveRequestController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveRequestCommand { Id = id });
            return NoContent();
        }
    }
}
