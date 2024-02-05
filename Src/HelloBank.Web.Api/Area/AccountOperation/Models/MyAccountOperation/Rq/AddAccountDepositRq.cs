namespace HelloBank.Web.Api.Area.AccountOperation.Models.MyAccountOperation.Rq;

public class AddAccountDepositRq
{
    /// <summary>
    /// 用戶身份證號碼
    /// </summary>
    public string UserIdentityNo { get; set; }
    
    /// <summary>
    /// 帳戶帳號
    /// </summary>
    public string AccountNo { get; set; }

    /// <summary>
    /// 金額
    /// </summary>
    public decimal Amount { get; set; }
}