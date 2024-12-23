using AutoMapper;
using Commissions.Manager.Employees;
using Commissions.Manager.Customers;
using Volo.Abp.AutoMapper;
using Commissions.Manager.Commissions;

namespace Commissions.Manager;

public class ManagerApplicationAutoMapperProfile : Profile
{
    public ManagerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Employee, EmployeeDto>().IgnoreAuditedObjectProperties().ReverseMap();
        CreateMap<CreateUpdateEmployeeDto, Employee>().ReverseMap();
        CreateMap<Customer, CustomerDto>();
        CreateMap<Commission, CommissionDto>();
        CreateMap<CreateUpdateCommissionDto, Commission>();
        CreateMap<CommissionDto, CreateUpdateCommissionDto>();
        CreateMap<Customer, CustomerLookupDto>();
    }
}
