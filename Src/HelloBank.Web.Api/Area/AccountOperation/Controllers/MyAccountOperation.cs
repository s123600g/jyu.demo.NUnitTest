using HelloBank.Web.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloBank.Web.Api.Area.AccountOperation.Controllers
{
    [Area("AccountOperation")]
    public class MyAccountOperation : BaseController
    {
        public MyAccountOperation()
        {
        }

        [HttpGet("QueryAccountBalances")]
        public IActionResult QueryAccountBalances()
        {
            return Ok();
        }
    }
}
