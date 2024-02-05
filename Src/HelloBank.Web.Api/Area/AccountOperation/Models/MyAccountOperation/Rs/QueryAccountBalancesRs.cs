namespace HelloBank.Web.Api.Area.AccountOperation.Models.MyAccountOperation.Rs;

public class QueryAccountBalancesRs
{
    /// <summary>
    /// 用戶身份證號碼
    /// </summary>
    public string? UserIdentityNo { get; set; }
    
    /// <summary>
    /// 用戶名稱
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// 帳戶帳號
    /// </summary>
    public string? AccountNo { get; set; }

    /// <summary>
    /// 帳戶餘額
    /// </summary>
    public decimal? AccountBalances { get; set; }
}