using ExceptionLib.Exceptions;
using HelloBank.Web.Api.Models.Services.AccountCoreOperationService;
using HelloBank.Web.Api.Services.AccountCoreOperationService;
using HelloBank.Web.Api.Services.AccountTransactionService;
using HelloBankDbLib.Dao;
using NSubstitute;

namespace HelloBank.Web.Api.Test.Services.AccountTransactionService;

[TestFixture]
[TestOf(typeof(AccountTransaction))]
public class AccountTransactionTest
{
    private IAccountCoreOperation _accountCoreOperation;
    private IAccountTransaction _accountTransaction;

    [SetUp]
    protected void SetUp()
    {
        _accountCoreOperation = Substitute.For<IAccountCoreOperation, AccountCoreOperation>(
            new HelloBankDbContext()
        );

        _accountTransaction = new AccountTransaction(
            _accountCoreOperation
        );
    }

    /// <summary>
    /// 測試案例 For GetAccountBalances: 資料庫查無用戶資料是否拋出DataNotFoundException
    /// </summary>
    [Test]
    public void CheckGetAccountBalancesNotFoundUserTest()
    {
        #region Arrange

        _accountCoreOperation.QueryAccountBasicInfo(
            Arg.Any<string>()
        ).Returns(
            Task.FromResult<AccountBasicInfo?>(null)
        );

        #endregion

        #region Act

        var act = _accountTransaction.GetAccountBalances(
            argUserIdentityNo: ""
            , argAccountNo: ""
        );

        #endregion

        #region Assert

        Assert.ThrowsAsync<DataNotFoundException>(
            async () => { await act; }
        );

        #endregion
    }

    /// <summary>
    /// 測試案例 For GetAccountBalances: 查無用戶底下對應帳戶資料是否拋出AccountNotFoundException
    /// </summary>
    [Test]
    public void CheckGetAccountBalancesNotFoundAccountTest()
    {
        #region Arrange

        AccountBasicInfo mockQueryDbData = new AccountBasicInfo
        {
            Accounts = new List<AccountDetail>
            {
                new AccountDetail
                {
                    AccountNo = "00011122233445",
                    AccountBalances = 1000
                },
                new AccountDetail
                {
                    AccountNo = "00022122523998",
                    AccountBalances = 5000
                }
            }
        };

        _accountCoreOperation.QueryAccountBasicInfo(
            Arg.Any<string>()
        ).Returns(
            Task.FromResult<AccountBasicInfo?>(mockQueryDbData)
        );

        #endregion

        #region Act

        var act = _accountTransaction.GetAccountBalances(
            argUserIdentityNo: "A123456789"
            , argAccountNo: "12345678900000"
        );

        #endregion
        
        #region Assert

        Assert.ThrowsAsync<AccountNotFoundException>(
            async () => { await act; }
        );

        #endregion
    }
}