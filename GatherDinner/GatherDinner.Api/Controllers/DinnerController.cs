using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GatherDinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class DinnerController : ControllerBase
{
    [HttpGet("list")]
    public IActionResult ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}