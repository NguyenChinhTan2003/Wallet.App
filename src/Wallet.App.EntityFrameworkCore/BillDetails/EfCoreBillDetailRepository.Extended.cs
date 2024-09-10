using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Users;
using Wallet.App.EntityFrameworkCore;

namespace Wallet.App.BillDetails
{
    public class EfCoreBillDetailRepository : EfCoreBillDetailRepositoryBase, IBillDetailRepository
    {
        public EfCoreBillDetailRepository(IDbContextProvider<AppDbContext> dbContextProvider,ICurrentUser currentUser)
            : base(dbContextProvider, currentUser)
        {

        }
    }
}