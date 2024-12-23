using Commissions.Manager.Samples;
using Xunit;

namespace Commissions.Manager.EntityFrameworkCore.Applications;

[Collection(ManagerTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<ManagerEntityFrameworkCoreTestModule>
{

}
