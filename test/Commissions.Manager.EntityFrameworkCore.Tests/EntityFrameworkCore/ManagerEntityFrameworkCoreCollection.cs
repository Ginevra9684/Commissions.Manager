using Xunit;

namespace Commissions.Manager.EntityFrameworkCore;

[CollectionDefinition(ManagerTestConsts.CollectionDefinitionName)]
public class ManagerEntityFrameworkCoreCollection : ICollectionFixture<ManagerEntityFrameworkCoreFixture>
{

}
