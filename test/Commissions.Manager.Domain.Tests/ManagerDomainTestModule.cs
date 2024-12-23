using Volo.Abp.Modularity;

namespace Commissions.Manager;

[DependsOn(
    typeof(ManagerDomainModule),
    typeof(ManagerTestBaseModule)
)]
public class ManagerDomainTestModule : AbpModule
{

}
