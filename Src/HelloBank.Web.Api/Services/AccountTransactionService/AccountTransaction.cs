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

    public Task<decimal> QueryAccountBalances(
        string argUserIdentityNo
        , string argAccountNo
    )
    {
        throw new NotImplementedException();
    }

    public Task AddAccountDeposit(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    )
    {
        throw new NotImplementedException();
    }

    public Task WithdrawalAccountDeposit(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    )
    {
        throw new NotImplementedException();
    }
}