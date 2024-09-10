using Wallet.App.Samples;
using Xunit;

namespace Wallet.App.EntityFrameworkCore.Domains;

[Collection(AppTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AppEntityFrameworkCoreTestModule>
{

}
