using AutoMapper;
using Commissions.Manager.Customers;
using Commissions.Manager.Employees;

namespace Commissions.Manager.Web;

public class ManagerWebAutoMapperProfile : Profile
{
    public ManagerWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        CreateMap<EmployeeDto, CreateUpdateEmployeeDto>().ReverseMap();
        CreateMap<CustomerDto, CreateUpdateCustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();
    }
}