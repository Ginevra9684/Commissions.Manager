using Commissions.Manager.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Commissions.Manager.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ManagerEntityFrameworkCoreModule),
    typeof(ManagerApplicationContractsModule)
)]
public class ManagerDbMigratorModule : AbpModule
{
}
