using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Commissions.Manager.Employees;

public class EmployeeCommission : AuditedEntity<Guid>
{
    public Guid EmployeeId { get; set; }
    public Guid CommissionId { get; set; }
    public RoleType Role { get; set; }
    public int TotalHours { get; set; }
}

