using Commissions.Manager.Samples;
using Xunit;

namespace Commissions.Manager.EntityFrameworkCore.Domains;

[Collection(ManagerTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<ManagerEntityFrameworkCoreTestModule>
{

}
