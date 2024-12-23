using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commissions.Manager.Commissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Commissions.Manager.Customers;

public class CustomerAppService :
        CrudAppService<
        Customer,
        CustomerDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCustomerDto>,
    ICustomerAppService
{
    private readonly CommissionAppService _commissionAppService;
    public CustomerAppService(IRepository<Customer, Guid> repository, CommissionAppService commissionAppService ) : base(repository)
    {
        _commissionAppService = commissionAppService;
    }

    [RemoteService] 
    public async Task<PagedResultDto<CustomerDto>> GetAllCustomersWithCommissionsAsync(PagedAndSortedResultRequestDto input)
    {
        // Get total count for pagination
        var totalCount = await Repository.CountAsync();

        // Get all customers with paginaton
        var customers = await Repository.GetPagedListAsync(
            skipCount: input.SkipCount,
            maxResultCount: input.MaxResultCount,
            sorting: input.Sorting
            );

        var customersDto = ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
        foreach (var customer in customersDto)
        {
            // Fetch the commissions from currently cicled customer
            var customerCommissions = await _commissionAppService.GetCommissionsByCustomer(customer.Id);

            // Map the customer to the CustomerDto

            customer.CommissionNames = customerCommissions.Select(c => c.Name).ToList();
        }

        return new PagedResultDto<CustomerDto>
        {
            TotalCount = totalCount,
            Items = customersDto
        };
    }

    public override async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
    {
        var customer = ObjectMapper.Map<CreateUpdateCustomerDto, Customer>(input);
        await Repository.InsertAsync(customer);
        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }

    public override async Task<CustomerDto> UpdateAsync(Guid id, CreateUpdateCustomerDto input)
    {
        var customer = await Repository.GetAsync(id);
        ObjectMapper.Map(input, customer);
        await Repository.UpdateAsync(customer);
        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }

    public override async Task DeleteAsync(Guid id)
    {
        await Repository.DeleteAsync(id);
    }
}

