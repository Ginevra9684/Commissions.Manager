using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Commissions.Manager.Commissions;
using Commissions.Manager.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Volo.Abp.Application.Dtos;

namespace Commissions.Manager.Web.Pages.Customers;

public class EditModalModel : ManagerPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateCustomerDto Customer { get; set; }

    private readonly ICustomerAppService _customerAppService;

    public EditModalModel(ICustomerAppService customerAppService)
    {
        _customerAppService = customerAppService;
    }
    public async Task OnGetAsync()
    {
        var customerDto = await _customerAppService.GetAsync(Id);
        Customer = ObjectMapper.Map < CustomerDto, CreateUpdateCustomerDto > (customerDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        try
        {
            await _customerAppService.UpdateAsync(Id, Customer);
            return NoContent();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex, "Error updating customer");
            throw;
        }
    }
}
