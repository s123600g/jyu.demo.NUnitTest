using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloBank.Web.Api.Controllers
{
    [Route("[area]/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
