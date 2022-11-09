using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SchoolFaceRecognition.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> All(CancellationToken cancellationToken)
        {
            return new ObjectResult(0);
        }
    }
}
