using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Commissions.Manager.Customers;
using Commissions.Manager.Employees;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Commissions.Manager.Commissions;

public class CommissionAppService :
        CrudAppService<
        Commission,
        CommissionDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdateCommissionDto>,
    ICommissionAppService
{
    private readonly IRepository<Customer, Guid> _customerRepository;
    private readonly IMapper _mapper;
    public CommissionAppService(
        IRepository<Commission, Guid> repository,
        IRepository<Customer, Guid> customerRepository,
        IMapper mapper) : base(repository)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    [RemoteService]
    public async Task<PagedResultDto<CommissionDto>> GetAllCommissionsWithCustomerNamesAsync(PagedAndSortedResultRequestDto input)
    {
        // Get total count for pagination
        var totalCount = await Repository.CountAsync();

        // Get all commissions with pagination
        var commissions = await Repository.GetPagedListAsync(
            skipCount: input.SkipCount,
            maxResultCount: input.MaxResultCount,
            sorting: input.Sorting
        );

        var commissionsDto = ObjectMapper.Map<List<Commission>, List<CommissionDto>>(commissions);

        // Get all relevant customers at once
        var customerIds = commissionsDto.Select(c => c.CustomerId).Distinct().ToList();
        var customers = await _customerRepository.GetListAsync(c => customerIds.Contains(c.Id));

        // Map customer names to commissions
        foreach (var commission in commissionsDto)
        {
            var customer = customers.FirstOrDefault(c => c.Id == commission.CustomerId);
            commission.CustomerName = customer?.Name;
        }

        return new PagedResultDto<CommissionDto>
        {
            TotalCount = totalCount,
            Items = commissionsDto
        };
    }

    // Keep your existing CRUD methods
    public override async Task<CommissionDto> CreateAsync(CreateUpdateCommissionDto input)
    {
        var customer = await _customerRepository.GetAsync(input.CustomerId);
        if (customer == null)
        {
            throw new UserFriendlyException("Customer not found");
        }
        var commission = await base.CreateAsync(input);
        if (await Repository.GetAsync(commission.Id) is Commission createdCommission)
        {
            createdCommission.EmployeeIds = new List<Guid>();
            await Repository.UpdateAsync(createdCommission);
        }

        // Update the customer's CommissionIds list
        customer.CommissionIds ??= new List<Guid>();
        customer.CommissionIds.Add(commission.Id);
        await _customerRepository.UpdateAsync(customer);

        return commission;
    }

    public override async Task<CommissionDto> UpdateAsync(Guid id, CreateUpdateCommissionDto input)
    {
        var commission = await Repository.GetAsync(id);

        // Check if the commission exists
        if (commission == null)
        {
            throw new UserFriendlyException("Commission not found");
        }

        var currentCustomer = await _customerRepository.GetAsync(input.CustomerId);
        if (currentCustomer == null)
        {
            throw new UserFriendlyException("Customer not found");
        }

        // Retrieve new customer associated with the commission
        var newCustomer = await _customerRepository.GetAsync(input.CustomerId);
        if (newCustomer == null)
        {
            throw new UserFriendlyException("New customer for commission not found");
        }

        // Update customers' commisions' lists
        if (commission.CustomerId != input.CustomerId)
        {
            // Remove from previous customer
            currentCustomer.CommissionIds?.Remove(commission.Id);

            // Add to new customer
            newCustomer.CommissionIds ??= new List<Guid>();
            newCustomer.CommissionIds.Add(commission.Id);

            // Save changes for both
            await _customerRepository.UpdateAsync(currentCustomer);
            await _customerRepository.UpdateAsync(newCustomer);
        }

        return await base.UpdateAsync(id, input);
    }

    public async Task<List<CustomerLookupDto>> GetCustomerLookupAsync()
    {
        var customers = await _customerRepository.GetListAsync();
        return ObjectMapper.Map<List<Customer>, List<CustomerLookupDto>>(customers);
    }

    public async Task<List<CommissionDto>> GetCommissionsByCustomer(Guid customerId)
    {
        var domainCommissions = await Repository.GetListAsync(x => x.CustomerId == customerId);
        // convert and return to dto
        return _mapper.Map<List<CommissionDto>>(domainCommissions);
    }
}
