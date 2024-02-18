using HelloBank.Web.Api.Area.AccountOperation.Models.MyAccountOperation.Rq;
using HelloBank.Web.Api.Area.AccountOperation.Models.MyAccountOperation.Rs;
using HelloBank.Web.Api.Controllers;
using HelloBank.Web.Api.Services.AccountTransactionService;
using Microsoft.AspNetCore.Mvc;

namespace HelloBank.Web.Api.Area.AccountOperation.Controllers
{
    [Area("Account")]
    public class AccountOperationController : BaseController
    {
        private readonly IAccountTransaction _accountTransaction;

        public AccountOperationController(IAccountTransaction argAccountTransaction)
        {
            _accountTransaction = argAccountTransaction ??
                                  throw new ArgumentNullException(nameof(argAccountTransaction));
        }

        [HttpGet]
        public async Task<ActionResult<QueryAccountBalancesRs>> QueryAccountBalances(
            [FromQuery] QueryAccountBalancesRq argRq
        )
        {
            var queryData = await _accountTransaction.GetAccountBalances(
                argUserIdentityNo: argRq.UserIdentityNo
                , argAccountNo: argRq.AccountNo
            );

            return new QueryAccountBalancesRs
            {
                UserIdentityNo = queryData.UserIdentityNo,
                Name = queryData.UserName,
                AccountNo = queryData.AccountNo,
                AccountBalances = queryData.AccountBalances
            };
        }

        [HttpPost]
        public async Task<ActionResult> AddAccountDeposit(
            [FromBody] AddAccountDepositRq argRq
        )
        {
            await _accountTransaction.AddAccountDeposit(
                argUserIdentityNo: argRq.UserIdentityNo
                , argAccountNo: argRq.AccountNo
                , argAmount: argRq.Amount
            );

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> WithdrawalAccountDeposit(
            [FromBody] WithdrawalAccountDepositRq argRq
        )
        {
            await _accountTransaction.WithdrawalAccountDeposit(
                argUserIdentityNo: argRq.UserIdentityNo
                , argAccountNo: argRq.AccountNo
                , argAmount: argRq.Amount
            );

            return Ok();
        }
    }
}