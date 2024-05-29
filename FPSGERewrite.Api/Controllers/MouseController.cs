using FPSGERewrite.Api.Commands;
using FPSGERewrite.Api.Query;
using FPSGERewrite.DataService.Repositories.Interfaces;
using FPSGERewrite.Entities.DbSet;
using FPSGERewrite.Entities.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FPSGERewrite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMouse()
        {
            var query = new GetAllMouseQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetMouseQuery(id);

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProductAsync(CreateMouseRequest mouseRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var command = new AddMouseCommand(mouseRequest);

            var result = await _mediator.Send(command);

            return result ? Ok(result) : BadRequest();
        }

    }
}
