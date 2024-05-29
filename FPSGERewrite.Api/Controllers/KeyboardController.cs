﻿using FPSGERewrite.Api.Commands;
using FPSGERewrite.Api.Query;
using FPSGERewrite.DataService.Repositories.Interfaces;
using FPSGERewrite.Entities.DbSet;
using FPSGERewrite.Entities.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;

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


        [HttpPost]
        public async Task<IActionResult> AddProductAsync(CreateKeyboardRequest keyboardRequest)
        {
            if(!ModelState.IsValid) { return BadRequest(); }

            var command = new AddKeyboardCommand(keyboardRequest);

            var result = await _mediator.Send(command);

            return result ? Ok(result) : BadRequest();
        }
    }
}