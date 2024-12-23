using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;
using Microsoft.Extensions.Localization;
using Commissions.Manager.Localization;

namespace Commissions.Manager.Web;

[Dependency(ReplaceServices = true)]
public class ManagerBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<ManagerResource> _localizer;

    public ManagerBrandingProvider(IStringLocalizer<ManagerResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
