using System;

namespace Wallet.App.BillDetails;

public abstract class BillDetailDownloadTokenCacheItemBase
{
    public string Token { get; set; } = null!;
}