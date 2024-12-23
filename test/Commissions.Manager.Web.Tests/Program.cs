using Microsoft.AspNetCore.Builder;
using Commissions.Manager;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<ManagerWebTestModule>();

public partial class Program
{
}
