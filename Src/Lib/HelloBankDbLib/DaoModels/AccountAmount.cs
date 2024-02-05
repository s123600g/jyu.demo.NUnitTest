using System;
using System.Collections.Generic;

namespace HelloBankDbLib.DaoModels;

public partial class AccountAmount
{
    public string AccountNo { get; set; } = null!;

    public decimal Amount { get; set; }
}
