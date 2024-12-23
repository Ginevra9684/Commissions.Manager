using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Commissions.Manager.Customers;

public class CustomerDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<string> CommissionNames { get; set; } = new List<string>();
}

