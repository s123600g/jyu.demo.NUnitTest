jyu.demo.NUnitTest
-------------------

### 專案環境：

1. Web API：ASP\.NET CORE 8
2. 測試框架
   * NUnit：https://docs.nunit.org/index.html
   * NSubstitute：https://nsubstitute.github.io/help/getting-started/

Web API範例專案初始設定

1. 複製`Db/HelloBank.sqlite`。
2. 在`Src\HelloBank.Web.Api\Db`內貼上複製`HelloBank.sqlite`。
3. 運行專案啟動Swagger。
4. 測試API --> `Account/AccountOperation/QueryAccountBalances`
   * API Request參數內容可以參考CUST_ACCOUNT_MAPPING資料表。

### 專案結構：


| 目錄    | 專案名稱               | 簡介                  |
| :-------- | ------------------------ | :---------------------- |
| Src     | HelloBank.Web.Api      | Web API範例專案       |
| Src/Lib | HelloBankDbLib         | EFCore產製ORM Library |
| Src/Lib | ExceptionLib           | 自訂Exception Library |
| Db      | HelloBank.sqlite       | DB範例檔-SQLite       |
| Test    | HelloBank.Web.Api.Test | 測試範例專案          |
| Test    | HelloWorld.Test        | 測試範例專案          |
