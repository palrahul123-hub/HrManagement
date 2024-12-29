using HrLeaveManagament.Application.DTOs.LeaveType;
using HrLeaveManagament.Application.Features.LeaveType.Request.Command;
using HrLeaveManagament.Application.Features.LeaveType.Request.Query;
using HrLeaveManagament.Application.Features.LeaveTypes.Request.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveTypeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
            return Ok(leaveTypes);
        }

        // GET api/<LeaveTypeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaveType = await _mediator.Send(new GetLeaveTypeByIdRequest() { Id = id });
            return Ok(leaveType);
        }

        // POST api/<LeaveTypeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveTypeDto createLeaveTypeDto)
        {
            var command = new CreateLeaveTypeRequest()
            {
                createLeave = createLeaveTypeDto
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // PUT api/<LeaveTypeController>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] LeaveTypeDto leaveTypeDto)
        {
            var command = new UpdateLeaveTypeRequest()
            {
                LeaveType = leaveTypeDto
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        // DELETE api/<LeaveTypeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveTypeCommand { Id = id });
            return NoContent();
        }
    }
}
