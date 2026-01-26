namespace _4EPlatform_LegalManagement_API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    [EnableRateLimiting("FixedWindowPolicy")]
    public class BaseController : ControllerBase
    {
    }
}
