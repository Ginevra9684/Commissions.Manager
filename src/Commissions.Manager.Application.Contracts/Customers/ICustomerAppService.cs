using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commissions.Manager.Employees;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Commissions.Manager.Customers;

public interface ICustomerAppService :
    ICrudAppService<
        CustomerDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerDto>
{
    Task<PagedResultDto<CustomerDto>> GetAllCustomersWithCommissionsAsync(PagedAndSortedResultRequestDto input);
}

