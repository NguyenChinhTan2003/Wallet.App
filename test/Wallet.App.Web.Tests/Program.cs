using Microsoft.AspNetCore.Builder;
using Wallet.App;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<AppWebTestModule>();

public partial class Program
{
}
