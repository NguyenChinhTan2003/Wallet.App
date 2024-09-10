using Wallet.App.PaymentTypeCategories;
using Volo.Abp.Identity;

using System;
using System.Collections.Generic;

namespace Wallet.App.BillDetails
{
    public abstract class BillDetailWithNavigationPropertiesBase
    {
        public BillDetail BillDetail { get; set; } = null!;

        public PaymentTypeCategory PaymentTypeCategory { get; set; } = null!;
        public IdentityUser IdentityUser { get; set; } = null!;
        

        
    }
}