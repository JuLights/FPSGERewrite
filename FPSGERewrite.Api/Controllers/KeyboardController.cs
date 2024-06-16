using FPSGERewrite.Application.Commands;
using FPSGERewrite.Application.Query;
using FPSGERewrite.Application.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FPSGERewrite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public KeyboardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllKeyboard()
        {
            var query = new GetAllKeyboardQuery();

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetKeyboardQuery(id);

            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddProductAsync(CreateKeyboardRequest keyboardRequest)
        {
            if (!ModelState.IsValid) { return BadRequest(); }

            var command = new AddKeyboardCommand(keyboardRequest);

            var result = await _mediator.Send(command);

            return result ? Ok(result) : BadRequest();
        }
    }
}
