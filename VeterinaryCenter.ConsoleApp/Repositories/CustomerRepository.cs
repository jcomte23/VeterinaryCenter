using VeterinaryCenter.ConsoleApp.Data;
using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Interfaces;

namespace VeterinaryCenter.ConsoleApp.Repositories;

internal class CustomerRepository : ICustomerRepository
{
    public void AddCustomer(Customer customer)
    {
        Database.Customers.Add(customer);
    }

    public void DeleteCustomer(Guid id)
    {
        var customer = GetCustomerById(id);
        if (customer is not null)
        {
            Database.Customers.Remove(customer);
        }
    }

    public List<Customer> GetAllCustomers()
    {
        return Database.Customers;
    }

    public Customer? GetCustomerById(Guid id)
    {
        return Database.Customers.FirstOrDefault(c => c.Id == id);
    }

    public void UpdateCustomer(Customer customer)
    {
        var index = Database.Customers.FindIndex(c => c.Id == customer.Id);
        if (index != -1)
        {
            Database.Customers[index] = customer;
        }
    }
}

