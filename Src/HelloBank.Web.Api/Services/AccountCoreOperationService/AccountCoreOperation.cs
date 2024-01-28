using HelloBank.Web.Api.Models.Services.AccountCoreOperationService;
using HelloBankDbLib.Dao;
using Microsoft.EntityFrameworkCore;

namespace HelloBank.Web.Api.Services.AccountCoreOperationService;

public class AccountCoreOperation : IAccountCoreOperation
{
    private readonly HelloBankDbContext _db;

    public AccountCoreOperation(
        HelloBankDbContext argHelloBankDbContext
    )
    {
        _db = argHelloBankDbContext ?? throw new ArgumentNullException(nameof(argHelloBankDbContext));
    }

    public async Task<CustInfo?> QueryUserInfo(
        string argUserIdentityNo
    )
    {
        var queryData = await _db.CustInfos.AsNoTracking().Where(t =>
            t.CustId == argUserIdentityNo
        ).FirstOrDefaultAsync();

        CustInfo? result = null;

        if (queryData != null)
        {
            result = new CustInfo
            {
                UserIdentityNo = queryData.CustId, UserName = queryData.Name
            };
        }

        return result;
    }

    public async Task<decimal?> QueryAccountBalances(
        string argAccountNo
    )
    {
        var queryData = await _db.AccountAmounts.AsNoTracking().Where(t =>
            t.AccountNo == argAccountNo
        ).FirstOrDefaultAsync();

        return queryData?.Amount;
    }

    public Task AddAccountBalances(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    )
    {
        throw new NotImplementedException();
    }

    public Task WithdrawalAccountBalances(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    )
    {
        throw new NotImplementedException();
    }
}