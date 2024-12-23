using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;


namespace Commissions.Manager.Employees;

    public class Employee : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime StartingDate { get; set; }
        public double HourlyFee { get; set; }
        public List<Guid>? CommissionIds { get; set; }
    }

