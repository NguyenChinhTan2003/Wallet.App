using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Wallet.App.Shared;

namespace Wallet.App.PaymentTypeCategories
{
    public partial interface IPaymentTypeCategoriesAppService : IApplicationService
    {

        Task<PagedResultDto<PaymentTypeCategoryDto>> GetListAsync(GetPaymentTypeCategoriesInput input);

        Task<PaymentTypeCategoryDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<PaymentTypeCategoryDto> CreateAsync(PaymentTypeCategoryCreateDto input);

        Task<PaymentTypeCategoryDto> UpdateAsync(int id, PaymentTypeCategoryUpdateDto input);
        Task DeleteByIdsAsync(List<int> paymenttypecategoryIds);

        Task DeleteAllAsync(GetPaymentTypeCategoriesInput input);
        Task<Wallet.App.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}