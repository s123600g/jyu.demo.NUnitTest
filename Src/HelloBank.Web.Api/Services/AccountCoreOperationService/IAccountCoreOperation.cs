using HelloBank.Web.Api.Models.Services.AccountCoreOperationService;

namespace HelloBank.Web.Api.Services.AccountCoreOperationService;

public interface IAccountCoreOperation
{
    /// <summary>
    /// 查詢帳戶基本資訊
    /// </summary>
    /// <param name="argUserIdentityNo">用戶身份證號碼</param>
    /// <returns>
    ///<see cref="AccountBasicInfo"/>
    /// </returns>
    Task<AccountBasicInfo?> QueryAccountBasicInfo(
        string argUserIdentityNo
    );

    /// <summary>
    /// 新增帳戶餘額
    /// </summary>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <param name="argAmount">金額</param>
    /// <returns></returns>
    Task AddAccountBalances(
        string argAccountNo
        , decimal argAmount
    );

    /// <summary>
    /// 提取帳戶餘額
    /// </summary>
    /// <param name="argAccountNo">帳戶帳號</param>
    /// <param name="argAmount">金額</param>
    Task WithdrawalAccountBalances(
        string argAccountNo
        , decimal argAmount
    );
}