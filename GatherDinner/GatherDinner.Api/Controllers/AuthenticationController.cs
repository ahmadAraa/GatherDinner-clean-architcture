using GatherDinner.Api.Filters;
using GatherDinner.Application.Authentication.Commands;
using GatherDinner.Application.Authentication.Common;
using GatherDinner.Application.Authentication.Queries.Login;

using GatherDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GatherDinner.Api.Controllers;

[ApiController]
[Route("auth")]

public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;
  

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
      
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        AuthenticationResult authResult = await _mediator.Send(command);

      
        return Ok(authResult);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new  LoginQuery(request.Email, request.Password);
        AuthenticationResult authResult = await _mediator.Send(query);

        
        return Ok(authResult);
    }
}