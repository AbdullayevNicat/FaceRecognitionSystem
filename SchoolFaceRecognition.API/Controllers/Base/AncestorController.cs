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
                HttpStatusCode.NotFound => NotFound(result),
                HttpStatusCode.BadRequest => BadRequest(result),
                HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, result),
                _ => StatusCode((int)HttpStatusCode.NotFound, result),
            };
        }
    }
}
