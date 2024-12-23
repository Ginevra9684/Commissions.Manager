using Commissions.Manager.Commissions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace Commissions.Manager.Web.Pages.Commissions;

public class CreateModalModel : ManagerPageModel
{
    [BindProperty]
    public CreateUpdateCommissionDto Commission { get; set; }

    public List<CustomerLookupDto> Customers { get; set; }

    private readonly ICommissionAppService _commissionAppService;

    public CreateModalModel(ICommissionAppService commissionAppService)
    {
        _commissionAppService = commissionAppService;
    }

    public async Task OnGetAsync()
    {
        Commission = new CreateUpdateCommissionDto
        {
            IsActive = true
        };

        Customers = await _commissionAppService.GetCustomerLookupAsync();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Commission.CustomerId == Guid.Empty)
        {
            ModelState.AddModelError("Commission.CustomerId", "Customer is required.");
            return Page();  // Re-render the form with validation errors
        }

        // Create the commission and proceed with the logic
        await _commissionAppService.CreateAsync(Commission);
        return NoContent();
    }
}

