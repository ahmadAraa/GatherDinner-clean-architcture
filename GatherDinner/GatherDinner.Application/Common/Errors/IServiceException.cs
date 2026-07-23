using System.Net;

namespace GatherDinner.Application.Common.Errors
{
    public interface IServiceException
    {
         public HttpStatusCode StatusCode { get; }
         public string ErrorMessage { get; }
    }
}