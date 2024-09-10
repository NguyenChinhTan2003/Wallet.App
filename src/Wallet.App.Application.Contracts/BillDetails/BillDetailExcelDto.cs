using System;

namespace Wallet.App.BillDetails
{
    public abstract class BillDetailExcelDtoBase
    {
        public decimal Money { get; set; }
        public string Note { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
    }
}