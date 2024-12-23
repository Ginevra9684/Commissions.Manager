using System;
using System.Threading.Tasks;
using Commissions.Manager.Employees;
using Commissions.Manager.Customers;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Commissions.Manager;

public class CoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Employee, Guid> _employeeRepository;
    private readonly IRepository<Customer, Guid> _customerRepository;

    public CoreDataSeederContributor(
        IRepository<Employee, Guid> employeeRepository,
        IRepository<Customer, Guid> customerRepository)
    {
        _employeeRepository = employeeRepository;
        _customerRepository = customerRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _employeeRepository.GetCountAsync() == 0)
        {
            await _employeeRepository.InsertAsync(
            new Employee
            {
                Name = "Pier",
                Surname = "Luigi",
                Email = "MaildiProva@gmail.com",
                BirthDate = new DateTime(1995, 9, 27),
                StartingDate = new DateTime(2020, 4, 21),
                HourlyFee = 20.67
            },
            autoSave: true
        );

            await _employeeRepository.InsertAsync(
                new Employee
                {
                    Name = "Franca",
                    Surname = "Rossi",
                    Email = "MaildiProva2@gmail.com",
                    BirthDate = new DateTime(1980, 4, 20),
                    StartingDate = new DateTime(2010, 8, 6),
                    HourlyFee = 25.89
                },
                autoSave: true
            );

            await _employeeRepository.InsertAsync(
                new Employee
                {
                    Name = "Sara",
                    Surname = "Bianchi",
                    Email = "MaildiProva3@gmail.com",
                    BirthDate = new DateTime(2000, 8, 16),
                    StartingDate = new DateTime(2023, 6, 6),
                    HourlyFee = 18.59
                },
                autoSave: true
            );
        }

        // Seeds customers if there aren't any
        if (await _customerRepository.GetCountAsync() == 0)
        {
            await _customerRepository.InsertAsync(
                new Customer
                {
                    Name = "Tech Innovators Inc.",
                    Email = "contact@techinnovators.com"
                },
                autoSave: true
            );

            await _customerRepository.InsertAsync(
                new Customer
                {
                    Name = "Global Solutions Ltd.",
                    Email = "info@globalsolutions.com"
                },
                autoSave: true
            );

            await _customerRepository.InsertAsync(
                new Customer
                {
                    Name = "Eco Enterprises",
                    Email = "support@ecoenterprises.com"
                },
                autoSave: true
            );

            await _customerRepository.InsertAsync(
                new Customer
                {
                    Name = "GreenTech Industries",
                    Email = "contact@greentechindustries.com"
                },
                autoSave: true
            );
        }
    }
}