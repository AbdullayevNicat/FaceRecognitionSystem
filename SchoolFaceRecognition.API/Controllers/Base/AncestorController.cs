using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;
using System.Net;

namespace SchoolFaceRecognition.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AncestorController : ControllerBase
    {
        protected async Task<IActionResult> ResultAsync(Task<Response> response)
        {
            Response result = await response;

            return result.StatusCode switch
            {
                HttpStatusCode.OK => Ok(result),
                HttpStatusCode.Created=> StatusCode((int)HttpStatusCode.Created, result),
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.BadRequest => BadRequest(result),
                HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, result),
                _ => StatusCode((int)HttpStatusCode.NotFound, result),
            };
        }

        protected IActionResult Result(Response response)
        {
            return response.StatusCode switch
            {
                HttpStatusCode.OK => Ok(response),
                HttpStatusCode.Created => StatusCode((int)HttpStatusCode.Created, response),
                HttpStatusCode.NotFound => NotFound(response),
                HttpStatusCode.BadRequest => BadRequest(response),
                HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                _ => StatusCode((int)HttpStatusCode.NotFound, response),
            };
        }
    }
}
