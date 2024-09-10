using Wallet.App.Localization;
using Volo.Abp.Application.Services;

namespace Wallet.App;

/* Inherit your application services from this class.
 */
public abstract class AppAppService : ApplicationService
{
    protected AppAppService()
    {
        LocalizationResource = typeof(AppResource);
    }
}
