using HelloBank.Web.Api.Models.Services.AccountCoreOperationService;

namespace HelloBank.Web.Api.Services.AccountCoreOperationService;

public interface IAccountCoreOperation
{
    /// <summary>
    /// 查詢用戶資訊
    /// </summary>
    /// <param name="argUserIdentityNo">用戶身份證號碼</param>
    /// <returns></returns>
    Task<CustInfo?> QueryUserInfo(
        string argUserIdentityNo
    );

    /// <summary>
    /// 查詢帳戶餘額
    /// </summary>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <returns>
    ///<see cref="decimal"/>
    /// </returns>
    Task<decimal?> QueryAccountBalances(
       string argAccountNo
    );

    /// <summary>
    /// 新增帳戶餘額
    /// </summary>
    /// <param name="argUserIdentityNo">用戶身份證號碼</param>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <param name="argAmount">金額</param>
    /// <returns></returns>
    Task AddAccountBalances(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    );

    /// <summary>
    /// 提取帳戶餘額
    /// </summary>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <param name="argUserIdentityNo">用戶身份證號碼</param>
    /// <param name="argAmount">金額</param>
    Task WithdrawalAccountBalances(
        string argUserIdentityNo
        , string argAccountNo
        , decimal argAmount
    );
}