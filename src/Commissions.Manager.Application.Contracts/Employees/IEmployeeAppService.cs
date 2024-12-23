using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Commissions.Manager.Employees;

public interface IEmployeeAppService :
    ICrudAppService< 
        EmployeeDto, 
        Guid, 
        PagedAndSortedResultRequestDto, 
        CreateUpdateEmployeeDto> 
{

}