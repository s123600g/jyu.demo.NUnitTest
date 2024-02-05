namespace HelloBank.Web.Api.Models.Services.AccountCoreOperationService;

public class AccountDetail
{
    /// <summary>
    /// 帳戶帳號
    /// </summary>
    public string? AccountNo { get; set; }

    /// <summary>
    /// 帳戶餘額
    /// </summary>
    public decimal? AccountBalances { get; set; }
}