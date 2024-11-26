using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BankLiteBack.Enum
{
    public enum TransactionEnum
    {
        [Display(Name="收入")]
        income = 1,
        [Display(Name = "支出")]
        spend = 2,
        [Display(Name = "轉帳")]
        transfer = 3
    }

    public enum TransferStatus
    {
        fail = 0,
        success = 1,
    }
}
