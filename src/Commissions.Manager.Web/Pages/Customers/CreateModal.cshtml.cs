
using System;
using System.Threading.Tasks;
using Commissions.Manager.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Commissions.Manager.Web.Pages.Customers;

public class CreateModalModel : ManagerPageModel
{
    [BindProperty]
    public CreateUpdateCustomerDto Customer { get; set; }

    private readonly ICustomerAppService _customerAppService;

    public CreateModalModel(ICustomerAppService customerAppService)
    {
        _customerAppService = customerAppService;
    }

    public async Task OnGetAsync()
    {
        Customer = new CreateUpdateCustomerDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await _customerAppService.CreateAsync(Customer);
            return NoContent();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error creating customer");
            throw;
        }
    }
}
