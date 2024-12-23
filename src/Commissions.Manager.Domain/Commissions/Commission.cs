using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Commissions.Manager.Commissions;

public class Commission : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public CommissionType Type { get; set; }
    public bool IsActive { get; set; }
    public decimal Total {  get; set; }
    public Guid CustomerId { get; set; }
    public List<Guid>? EmployeeIds { get; set; }
}

