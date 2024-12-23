using Commissions.Manager.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Commissions.Manager.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class ManagerController : AbpControllerBase
{
    protected ManagerController()
    {
        LocalizationResource = typeof(ManagerResource);
    }
}
