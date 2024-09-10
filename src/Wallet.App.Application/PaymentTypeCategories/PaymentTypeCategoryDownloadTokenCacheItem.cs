using System;

namespace Wallet.App.PaymentTypeCategories;

public abstract class PaymentTypeCategoryDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}