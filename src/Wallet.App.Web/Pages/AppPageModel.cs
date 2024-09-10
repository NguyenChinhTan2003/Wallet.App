using Wallet.App.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Wallet.App.Web.Pages;

public abstract class AppPageModel : AbpPageModel
{
    protected AppPageModel()
    {
        LocalizationResourceType = typeof(AppResource);
    }
}
