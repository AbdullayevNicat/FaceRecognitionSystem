using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig;
using SchoolFaceRecognition.Core.Infrastructure.ResponseConfig.Base;

namespace SchoolFaceRecognition.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
    public class AncestorController : ControllerBase
    {
        private protected async Task<IActionResult> ResultAsync(Task<Response> response)
        {
            Response result = await response;

            return StatusCode((int)result.StatusCode, result);
        }

        private protected IActionResult Result(Response response)
        {
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
