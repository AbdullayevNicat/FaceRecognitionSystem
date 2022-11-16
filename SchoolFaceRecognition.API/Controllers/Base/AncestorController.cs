using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.Core.Infrastructure;
using System.Net;

namespace SchoolFaceRecognition.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AncestorController : ControllerBase
    {
        protected async Task<IActionResult> ResultAsync<T>(Task<Response<T>> response)
        {
            Response<T> result = await response;

            switch (result.Code)
            {
                case HttpStatusCode.OK:
                    return Ok(result);
                case HttpStatusCode.NotFound:
                    return NotFound(result);
                case HttpStatusCode.BadRequest:
                    return BadRequest(result);
                case HttpStatusCode.InternalServerError:
                    return StatusCode((int)HttpStatusCode.InternalServerError, result);
                default:
                    return StatusCode((int)HttpStatusCode.NotFound, result);
            }
        }
    }
}
