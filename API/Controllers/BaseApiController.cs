using API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ServiceFilter(typeof(LogUserActivity))]
    [ApiController]
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}
