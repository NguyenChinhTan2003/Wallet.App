using Volo.Abp.Modularity;

namespace Wallet.App;

[DependsOn(
    typeof(AppDomainModule),
    typeof(AppTestBaseModule)
)]
public class AppDomainTestModule : AbpModule
{

}
