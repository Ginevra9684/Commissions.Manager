using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commissions.Manager.Customers;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Commissions.Manager.Commissions;

public interface ICommissionAppService :
    ICrudAppService<
        CommissionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCommissionDto>
{
    Task<List<CustomerLookupDto>> GetCustomerLookupAsync();
}

