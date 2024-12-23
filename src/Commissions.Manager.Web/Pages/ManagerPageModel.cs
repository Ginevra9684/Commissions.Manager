using Commissions.Manager.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Commissions.Manager.Web.Pages;

public abstract class ManagerPageModel : AbpPageModel
{
    protected ManagerPageModel()
    {
        LocalizationResourceType = typeof(ManagerResource);
    }
}
