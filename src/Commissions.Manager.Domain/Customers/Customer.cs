using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Commissions.Manager.Customers;

public class Customer : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }

    public string Email { get; set; }
    public List<Guid>? CommissionIds { get; set; }

    //private Customer()
    //{

    //}

    //internal Customer(
    //    Guid id,
    //    string name)
    //    : base(id)
    //{
    //    SetName(name);
    //}


    //internal Customer ChangeName(string name)
    //{
    //    SetName(name);
    //    return this;
    //}

    //private void SetName(string name)
    //{
    //    Name = Check.NotNullOrWhiteSpace(
    //        name,
    //        nameof(name),
    //        maxLength: CustomerConsts.MaxNameLength
    //    );
    //}

}

