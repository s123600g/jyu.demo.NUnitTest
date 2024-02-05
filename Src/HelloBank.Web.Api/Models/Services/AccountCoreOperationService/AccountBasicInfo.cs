namespace HelloBank.Web.Api.Models.Services.AccountCoreOperationService;

public class AccountBasicInfo : CustInfo
{
    public List<AccountDetail> Accounts { get; set; } = new List<AccountDetail>();
}