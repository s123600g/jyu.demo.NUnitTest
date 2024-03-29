﻿using ExceptionLib.Exceptions;
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

        AccountBasicInfo mockQueryDbData = GenMockQueryDbData();

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

    /// <summary>
    /// 測試案例 For AddAccountDeposit: 資料庫查無用戶資料是否拋出DataNotFoundException
    /// </summary>
    [Test]
    public void CheckAddAccountDepositNotFoundUserTest()
    {
        #region Arrange

        _accountCoreOperation.QueryAccountBasicInfo(
            Arg.Any<string>()
        ).Returns(
            Task.FromResult<AccountBasicInfo?>(null)
        );

        #endregion

        #region Act

        var act = _accountTransaction.AddAccountDeposit(
            argUserIdentityNo: ""
            , argAccountNo: ""
            , argAmount: 1000
        );

        #endregion

        #region Assert

        Assert.ThrowsAsync<DataNotFoundException>(
            async () => { await act; }
        );

        #endregion
    }

    /// <summary>
    /// 測試案例 For AddAccountDeposit: 查無用戶底下對應帳戶資料是否拋出AccountNotFoundException
    /// </summary>
    [Test]
    public void CheckAddAccountDepositNotFoundAccountTest()
    {
        #region Arrange

        AccountBasicInfo mockQueryDbData = GenMockQueryDbData();

        _accountCoreOperation.QueryAccountBasicInfo(
            Arg.Any<string>()
        ).Returns(
            Task.FromResult<AccountBasicInfo?>(mockQueryDbData)
        );

        #endregion

        #region Act

        var act = _accountTransaction.AddAccountDeposit(
            argUserIdentityNo: "A123456789"
            , argAccountNo: "12345678900000"
            , argAmount: 1000
        );

        #endregion

        #region Assert

        Assert.ThrowsAsync<AccountNotFoundException>(
            async () => { await act; }
        );

        #endregion
    }

    /// <summary>
    /// 測試案例 For WithdrawalAccountDeposit: 資料庫查無用戶資料是否拋出DataNotFoundException
    /// </summary>
    [Test]
    public void CheckWithdrawalAccountDepositNotFoundUserTest()
    {
        #region Arrange

        _accountCoreOperation.QueryAccountBasicInfo(
            Arg.Any<string>()
        ).Returns(
            Task.FromResult<AccountBasicInfo?>(null)
        );

        #endregion

        #region Act

        var act = _accountTransaction.WithdrawalAccountDeposit(
            argUserIdentityNo: ""
            , argAccountNo: ""
            , argAmount: 1000
        );

        #endregion

        #region Assert

        Assert.ThrowsAsync<DataNotFoundException>(
            async () => { await act; }
        );

        #endregion
    }

    /// <summary>
    /// 測試案例 For WithdrawalAccountDeposit: 查無用戶底下對應帳戶資料是否拋出AccountNotFoundException
    /// </summary>
    [Test]
    public void CheckWithdrawalAccountDepositNotFoundAccountTest()
    {
        #region Arrange

        AccountBasicInfo mockQueryDbData = GenMockQueryDbData();

        _accountCoreOperation.QueryAccountBasicInfo(
            Arg.Any<string>()
        ).Returns(
            Task.FromResult<AccountBasicInfo?>(mockQueryDbData)
        );

        #endregion

        #region Act

        var act = _accountTransaction.WithdrawalAccountDeposit(
            argUserIdentityNo: "A123456789"
            , argAccountNo: "12345678900000"
            , argAmount: 1000
        );

        #endregion

        #region Assert

        Assert.ThrowsAsync<AccountNotFoundException>(
            async () => { await act; }
        );

        #endregion
    }

    /// <summary>
    /// 測試案例 For WithdrawalAccountDeposit: 金額不符合最低金額是否拋出InvalidAmountException
    /// </summary>
    [Test]
    [TestCase(900, TestName = "測試是否檢測出未達最低金額")]
    [TestCase(1100, TestName = "測試是否檢測出金額非以千為單位")]
    public void CheckWithdrawalAccountDepositInvalidAmountTest(
        decimal argAmount
    )
    {
        #region Arrange

        AccountBasicInfo mockQueryDbData = new AccountBasicInfo
        {
            Accounts = new List<AccountDetail>
            {
                new AccountDetail
                {
                    AccountNo = "12345678900000",
                    AccountBalances = argAmount
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

        var act = _accountTransaction.WithdrawalAccountDeposit(
            argUserIdentityNo: "A123456789"
            , argAccountNo: "12345678900000"
            , argAmount: argAmount
        );

        #endregion

        #region Assert

        Assert.ThrowsAsync<InvalidAmountException>(
            async () => { await act; }
        );

        #endregion
    }

    /// <summary>
    /// 測試案例 For WithdrawalAccountDeposit: 帳戶餘額不足是否拋出AccountBlanceNotEnoughException
    /// </summary>
    [Test]
    public void CheckWithdrawalAccountDepositAccountBlanceNotEnoughTest()
    {
        #region Arrange

        AccountBasicInfo mockQueryDbData = new AccountBasicInfo
        {
            Accounts = new List<AccountDetail>
            {
                new AccountDetail
                {
                    AccountNo = "12345678900000",
                    AccountBalances = 1000
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

        var act = _accountTransaction.WithdrawalAccountDeposit(
            argUserIdentityNo: "A123456789"
            , argAccountNo: "12345678900000"
            , argAmount: 2000
        );

        #endregion

        #region Assert

        Assert.ThrowsAsync<AccountBlanceNotEnoughException>(
            async () => { await act; }
        );

        #endregion
    }

    #region 內部處理邏輯

    private AccountBasicInfo GenMockQueryDbData()
    {
        return new AccountBasicInfo
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
    }

    #endregion
}