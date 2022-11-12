using Microsoft.AspNetCore.Mvc;
using SchoolFaceRecognition.Core.DTOs.Base;

namespace SchoolFaceRecognition.API.Controllers.Base
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AncestorController : ControllerBase
    {
        protected async Task<IActionResult> ResultAsync<T>(Task<Response<T>> response) 
        {
            return new ObjectResult(await response);
        }
    }
}
