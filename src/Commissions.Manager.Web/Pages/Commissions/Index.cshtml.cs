using Commissions.Manager.Commissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Commissions.Manager.Web.Pages.Commissions;

public class IndexModel : PageModel
{
    private readonly ICommissionAppService _commissionAppService;

    public IndexModel(ICommissionAppService commissionAppService)
    {
        _commissionAppService = commissionAppService;
    }
    public void OnGet()
    {
    }
}
