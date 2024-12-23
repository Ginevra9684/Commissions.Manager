using Volo.Abp.Modularity;

namespace Commissions.Manager;

[DependsOn(
    typeof(ManagerApplicationModule),
    typeof(ManagerDomainTestModule)
)]
public class ManagerApplicationTestModule : AbpModule
{

}
