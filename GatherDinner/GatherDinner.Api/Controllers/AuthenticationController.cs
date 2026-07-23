using GatherDinner.Api.Filters;
using GatherDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GatherDinner.Contracts.Authentication;

[ApiController]
[Route("auth")]

public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authenticationService;

    public AuthenticationController(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
      
        var authResponse = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);


        var response = new AuthenticationResponse(
            authResponse.User.Id,
            authResponse.User.FirstName,
            authResponse.User.LastName,
            authResponse.User.Email,
            authResponse.Token
        );
        return Ok(response);
        
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResponse = _authenticationService.Login(
            request.Email,
            request.Password);
        var response = new AuthenticationResponse(
            authResponse.User.Id,
            authResponse.User.FirstName,
            authResponse.User.LastName,
            authResponse.User.Email,
            authResponse.Token
        );
        return Ok(authResponse);
    }
}