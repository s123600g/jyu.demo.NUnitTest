namespace HelloBank.Web.Api.Models.Services.AccountCoreOperationService;

public class GetAccountBalancesRs
{
    /// <summary>
    /// 用戶身份證號碼
    /// </summary>
    public string? UserIdentityNo { get; set; }
    
    /// <summary>
    /// 用戶名稱
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 帳戶帳號
    /// </summary>
    public string? AccountNo { get; set; }

    /// <summary>
    /// 帳戶餘額
    /// </summary>
    public decimal? AccountBalances { get; set; }
}