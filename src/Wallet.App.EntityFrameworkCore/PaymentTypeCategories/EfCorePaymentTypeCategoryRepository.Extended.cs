using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Wallet.App.EntityFrameworkCore;

namespace Wallet.App.PaymentTypeCategories
{
    public class EfCorePaymentTypeCategoryRepository : EfCorePaymentTypeCategoryRepositoryBase, IPaymentTypeCategoryRepository
    {
        public EfCorePaymentTypeCategoryRepository(IDbContextProvider<AppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}