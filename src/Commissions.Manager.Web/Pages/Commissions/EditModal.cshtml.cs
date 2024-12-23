using Commissions.Manager.Commissions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Commissions.Manager.Web.Pages.Commissions;

public class EditModalModel : ManagerPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateCommissionDto Commission { get; set; }

    public List<CustomerLookupDto> Customers { get; set; }

    private readonly ICommissionAppService _commissionAppService;

    public EditModalModel(ICommissionAppService commissionAppService)
    {
        _commissionAppService = commissionAppService;
    }

    public async Task OnGetAsync()
    {
        var commissionDto = await _commissionAppService.GetAsync(Id);
        Commission = ObjectMapper.Map<CommissionDto, CreateUpdateCommissionDto>(commissionDto);
        Customers = await _commissionAppService.GetCustomerLookupAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _commissionAppService.UpdateAsync(Id, Commission);
        return NoContent();
    }
}
