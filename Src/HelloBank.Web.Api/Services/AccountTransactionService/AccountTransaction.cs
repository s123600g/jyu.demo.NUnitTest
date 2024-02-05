using ExceptionLib.Exceptions;
using HelloBank.Web.Api.Models.Services.AccountCoreOperationService;
using HelloBank.Web.Api.Services.AccountCoreOperationService;

namespace HelloBank.Web.Api.Services.AccountTransactionService;

public class AccountTransaction : IAccountTransaction
{
    private readonly IAccountCoreOperation _accountCoreOperation;

    public AccountTransaction(IAccountCoreOperation argAccountCoreOperation)
    {
        _accountCoreOperation =
            argAccountCoreOperation ?? throw new ArgumentNullException(nameof(argAccountCoreOperation));
    }

    public async Task<GetAccountBalancesRs?> GetAccountBalances(
        string argUserIdentityNo
        , string argAccountNo
    )
    {
        var queryData = await _accountCoreOperation.QueryAccountBasicInfo(
            argUserIdentityNo: argUserIdentityNo
        );

        #region 檢核1

        if (
            queryData == null
        )
        {
            throw new DataNotFoundException();
        }

        #endregion

        AccountDetail? accountEntity = queryData.Accounts.FirstOrDefault(t =>
            t.AccountNo == argAccountNo
        );

        #region 檢核2

        if (
            accountEntity == null
        )
        {
            throw new AccountNotFoundException();
        }

        #endregion

        return new GetAccountBalancesRs
        {
            UserIdentityNo = queryData.UserIdentityNo,
            UserName = queryData.UserName,
            AccountNo = accountEntity.AccountNo,
            AccountBalances = accountEntity.AccountBalances
        };
    }

    public async Task AddAccountDeposit(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    )
    {
        var queryData = await _accountCoreOperation.QueryAccountBasicInfo(
            argUserIdentityNo: argUserIdentityNo
        );

        #region 檢核1

        if (
            queryData == null
        )
        {
            throw new DataNotFoundException();
        }

        #endregion

        AccountDetail? accountEntity = queryData.Accounts.FirstOrDefault(t =>
            t.AccountNo == argAccountNo
        );

        #region 檢核2

        if (
            accountEntity == null
        )
        {
            throw new AccountNotFoundException();
        }

        #endregion
        
        await _accountCoreOperation.AddAccountBalances(
            argAccountNo: argAccountNo,
            argAmount: argAmount
        );
    }

    public async Task WithdrawalAccountDeposit(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    )
    {
        var queryData = await _accountCoreOperation.QueryAccountBasicInfo(
            argUserIdentityNo: argUserIdentityNo
        );

        #region 檢核1

        if (
            queryData == null
        )
        {
            throw new DataNotFoundException();
        }

        #endregion

        AccountDetail? accountEntity = queryData.Accounts.FirstOrDefault(t =>
            t.AccountNo == argAccountNo
        );

        #region 檢核2

        if (
            accountEntity == null
        )
        {
            throw new AccountNotFoundException();
        }

        #endregion

        #region 檢核3 && 執行

        if (
            accountEntity.AccountBalances.HasValue
            &&
            accountEntity.AccountBalances >= argAmount
        )
        {
            await _accountCoreOperation.WithdrawalAccountBalances(
                argAccountNo: argAccountNo
                , argAmount: argAmount
            );
        }
        else
        {
            throw new AccountBlanceNotEnoughException();
        }

        #endregion
    }
}