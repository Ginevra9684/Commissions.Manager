using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Commissions.Manager.Employees;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Commissions.Manager.Web.Pages.Employees;

public class CreateModalModel : ManagerPageModel
{
    [BindProperty]
    public CreateUpdateEmployeeDto Employee { get; set; }

    private readonly IEmployeeAppService _employeeAppService;

    public CreateModalModel(
        IEmployeeAppService employeeAppService)
    {
        _employeeAppService = employeeAppService;
    }

    public async Task OnGetAsync()
    {
        Employee = new CreateUpdateEmployeeDto();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _employeeAppService.CreateAsync(Employee);
        return NoContent();
    }
}
