using VeterinaryCenter.ConsoleApp.Entities;

namespace VeterinaryCenter.ConsoleApp.Interfaces;

internal interface ICustomerRepository
{
    void AddCustomer(Customer customer);
    List<Customer> GetAllCustomers();
    Customer? GetCustomerById(Guid id);
    void UpdateCustomer(Customer customer);
    void DeleteCustomer(Guid id);
}

