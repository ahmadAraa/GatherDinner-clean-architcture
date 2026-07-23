using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;
using GatherDinner.Application.Common.Errors;


namespace GatherDinner.Api.Controllers;

public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message)= exception switch
        {
            IServiceException serviceException =>((int) serviceException.StatusCode,serviceException.ErrorMessage),
          _  => (StatusCodes.Status500InternalServerError,"An unexpected Error has occured"),
        };
        return Problem(statusCode : statusCode, title: message);
    } 
}