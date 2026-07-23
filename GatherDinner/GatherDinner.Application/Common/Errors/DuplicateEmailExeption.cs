using System.Net;

namespace GatherDinner.Application.Common.Errors;

public class DuplicateEmailExeption : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exist";
}