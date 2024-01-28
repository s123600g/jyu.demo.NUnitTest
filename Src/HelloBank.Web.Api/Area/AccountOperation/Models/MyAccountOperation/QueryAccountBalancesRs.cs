namespace HelloBank.Web.Api.Area.AccountOperation.Models.MyAccountOperation;

public class QueryAccountBalancesRs
{
    /// <summary>
    /// 用戶名稱
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 帳戶帳號
    /// </summary>
    public string AccountNo { get; set; }

    /// <summary>
    /// 帳戶餘額
    /// </summary>
    public decimal AccountBalances { get; set; }
}