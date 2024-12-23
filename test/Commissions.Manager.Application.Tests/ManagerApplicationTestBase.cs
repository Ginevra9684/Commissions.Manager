using Volo.Abp.Modularity;

namespace Commissions.Manager;

public abstract class ManagerApplicationTestBase<TStartupModule> : ManagerTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
