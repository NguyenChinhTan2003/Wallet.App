using Wallet.App.PaymentTypeCategories;
using Volo.Abp.Identity;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Wallet.App.BillDetails
{
    public abstract class BillDetailWithNavigationPropertiesDtoBase
    {
        public BillDetailDto BillDetail { get; set; } = null!;

        public PaymentTypeCategoryDto PaymentTypeCategory { get; set; } = null!;
        public IdentityUserDto IdentityUser { get; set; } = null!;

    }
}