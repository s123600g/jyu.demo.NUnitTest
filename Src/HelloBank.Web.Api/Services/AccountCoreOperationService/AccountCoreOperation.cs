using ExceptionLib.Exceptions;
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

    public async Task<AccountBasicInfo?> QueryAccountBasicInfo(
        string argUserIdentityNo
    )
    {
        AccountBasicInfo? result = null;

        var queryMappingData = await _db.CustAccountMappings.AsNoTracking().Where(t =>
            t.CustId == argUserIdentityNo
        ).ToListAsync();

        if (
            queryMappingData.Any()
        )
        {
            var queryUserData = await _db.CustInfos.AsNoTracking().Where(t =>
                t.CustId == argUserIdentityNo
            ).FirstOrDefaultAsync();

            List<string> accountNos = queryMappingData.Select(t =>
                t.AccountNo
            ).ToList();

            var queryAccountData = await _db.AccountAmounts.AsNoTracking().Where(t =>
                accountNos.Contains(t.AccountNo)
            ).ToListAsync();

            result = new AccountBasicInfo
            {
                UserIdentityNo = queryUserData?.CustId,
                UserName = queryUserData?.Name,
                Accounts = queryAccountData.Select(t => new AccountDetail
                {
                    AccountNo = t.AccountNo,
                    AccountBalances = t.Amount
                }).ToList()
            };
        }

        return result;
    }

    public async Task AddAccountBalances(
        string argAccountNo
        , decimal argAmount
    )
    {
        var dataEntity = await _db.AccountAmounts.Where(t =>
            t.AccountNo == argAccountNo
        ).FirstOrDefaultAsync();

        if (
            dataEntity != null
        )
        {
            dataEntity.Amount += argAmount;

            await _db.SaveChangesAsync();
        }
        else
        {
            throw new DataNotFoundException();
        }
    }

    public async Task WithdrawalAccountBalances(
        string argAccountNo
        , decimal argAmount
    )
    {
        var dataEntity = await _db.AccountAmounts.Where(t =>
            t.AccountNo == argAccountNo
        ).FirstOrDefaultAsync();

        if (
            dataEntity != null
        )
        {
            dataEntity.Amount -= argAmount;

            await _db.SaveChangesAsync();
        }
        else
        {
            throw new DataNotFoundException();
        }
    }
}