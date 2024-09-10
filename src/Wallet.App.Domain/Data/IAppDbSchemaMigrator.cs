using System.Threading.Tasks;

namespace Wallet.App.Data;

public interface IAppDbSchemaMigrator
{
    Task MigrateAsync();
}
