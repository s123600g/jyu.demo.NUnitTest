using HelloBank.Web.Api.Models.Services.AccountCoreOperationService;

namespace HelloBank.Web.Api.Services.AccountTransactionService;

public interface IAccountTransaction
{
    /// <summary>
    /// 查詢帳戶餘額
    /// </summary>
    /// <param name="argUserIdentityNo">用戶身份證號碼</param>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <returns>
    ///<see cref="decimal"/>
    /// </returns>
    Task<GetAccountBalancesRs?> GetAccountBalances(
        string argUserIdentityNo
        , string argAccountNo
    );
    
    /// <summary>
    /// 新增帳戶存款
    /// </summary>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <param name="argAmount">金額</param>
    /// <returns></returns>
    Task AddAccountDeposit(
        string argUserIdentityNo
        , string argAccountNo 
        , decimal argAmount
    );

    /// <summary>
    /// 提取帳戶存款
    /// </summary>
    /// <param name="argUserIdentityNo">用戶身份證號碼</param>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <param name="argAmount">金額</param>
    /// <returns></returns>
    Task WithdrawalAccountDeposit( 
        string argUserIdentityNo 
        , string argAccountNo 
        , decimal argAmount
    );
}