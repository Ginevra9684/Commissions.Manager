using System;
using Volo.Abp.Application.Dtos;

namespace Commissions.Manager.Commissions;

public class CommissionDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public CommissionType Type {  get; set; }
    public decimal Total { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
}