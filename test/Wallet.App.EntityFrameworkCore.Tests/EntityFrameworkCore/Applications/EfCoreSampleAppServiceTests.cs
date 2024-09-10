using Wallet.App.Samples;
using Xunit;

namespace Wallet.App.EntityFrameworkCore.Applications;

[Collection(AppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AppEntityFrameworkCoreTestModule>
{

}
