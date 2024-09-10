using Xunit;

namespace Wallet.App.EntityFrameworkCore;

[CollectionDefinition(AppTestConsts.CollectionDefinitionName)]
public class AppEntityFrameworkCoreCollection : ICollectionFixture<AppEntityFrameworkCoreFixture>
{

}
