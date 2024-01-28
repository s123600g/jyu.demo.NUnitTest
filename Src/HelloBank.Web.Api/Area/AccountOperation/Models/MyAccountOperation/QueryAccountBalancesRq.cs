using Microsoft.Build.Framework;

namespace HelloBank.Web.Api.Area.AccountOperation.Models.MyAccountOperation;

public class QueryAccountBalancesRq
{
    /// <summary>
    /// 用戶身份證號碼
    /// </summary>
    public string UserIdentityNo { get; set; }

    /// <summary>
    /// 帳戶帳號
    /// </summary>
    public string AccountNo { get; set; }
}