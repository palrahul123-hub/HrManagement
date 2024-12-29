using HrLeaveManagament.Application.DTOs.LeaveAllocation;
using HrLeaveManagament.Application.Features.LeaveAllocations.Request.Command;
using HrLeaveManagament.Application.Features.LeaveAllocations.Request.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HrLeaveManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationListDto>>> Get()
        {
            var leaveAllocations = await _mediator.Send(new GetLeaveAllocationListRequest());
            return Ok(leaveAllocations);
        }

        // GET api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveAllocationDto>> Get(int id)
        {
            var leaveAllocation = await _mediator.Send(new GetLeaveAllocationDetailsRequest() { Id = id });
            return Ok(leaveAllocation);
        }

        // POST api/<LeaveAllocationController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateLeaveAllocationDto createLeaveAllocationDto)
        {
            var result = await _mediator.Send(new CreateLeaveAllocationRequest { CreateLeaveAllocationDto = createLeaveAllocationDto });
            return Ok(result);
        }

        // PUT api/<LeaveAllocationController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateLeaveAllocationDto leaveAllocationDto)
        {
            var result = await _mediator.Send(new UpdateLeaveAllocationRequest { allocationDto = leaveAllocationDto });
            return Ok(result);
        }

        // DELETE api/<LeaveAllocationController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteLeaveAllocationCommand { Id = id });
            return NoContent();
        }
    }
}
