using System;

namespace Wallet.App.PaymentTypeCategories
{
    public abstract class PaymentTypeCategoryExcelDtoBase
    {
        public string CategoryName { get; set; } = null!;
        public bool Status { get; set; }
        public string Description { get; set; } = null!;
        public DateTime LastModifiercationTime { get; set; }
    }
}