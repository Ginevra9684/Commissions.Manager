﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Commissions.Manager.Employees;

public class EmployeeAppService :
    CrudAppService<
    Employee,
    EmployeeDto,
    Guid,
    PagedAndSortedResultRequestDto,
    CreateUpdateEmployeeDto>,
IEmployeeAppService
{
    public EmployeeAppService(IRepository<Employee, Guid> repository) : base(repository)
    {
    }
}
