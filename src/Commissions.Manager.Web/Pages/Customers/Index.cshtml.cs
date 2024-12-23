using System.Collections.Generic;
using System.Threading.Tasks;
using Commissions.Manager.Customers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.Application.Dtos;

namespace Commissions.Manager.Web.Pages.Customers;

public class IndexModel : PageModel
{
    private readonly ICustomerAppService _customerAppService;

    public IndexModel(ICustomerAppService customerAppService)
    {
        _customerAppService = customerAppService;
    }
    public List<CustomerDto> Customers { get; set; }
    public async Task OnGetAsync()
    {
    }
}
