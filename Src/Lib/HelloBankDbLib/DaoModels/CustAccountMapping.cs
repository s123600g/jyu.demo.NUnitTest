using System;
using System.Collections.Generic;

namespace HelloBankDbLib.DaoModels;

public partial class CustAccountMapping
{
    public string CustId { get; set; } = null!;

    public string AccountNo { get; set; } = null!;
}
