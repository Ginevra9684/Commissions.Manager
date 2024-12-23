using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Commissions.Manager.Pages;

[Collection(ManagerTestConsts.CollectionDefinitionName)]
public class Index_Tests : ManagerWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
