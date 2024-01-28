using HelloBank.Web.Api.Area.AccountOperation.Models.MyAccountOperation;
using HelloBank.Web.Api.Controllers;
using HelloBank.Web.Api.Services.AccountTransactionService;
using Microsoft.AspNetCore.Mvc;

namespace HelloBank.Web.Api.Area.AccountOperation.Controllers
{
    [Area("Account")]
    public class AccountOperation : BaseController
    {
        private readonly IAccountTransaction _accountTransaction;

        public AccountOperation(IAccountTransaction argAccountTransaction)
        {
            _accountTransaction = argAccountTransaction ??
                                  throw new ArgumentNullException(nameof(argAccountTransaction));
        }

        [HttpGet("QueryAccountBalances")]
        public ActionResult<QueryAccountBalancesRs> QueryAccountBalances(
            [FromQuery] QueryAccountBalancesRq argRq
        )
        {
            return new QueryAccountBalancesRs
            {
            };
        }
    }
}