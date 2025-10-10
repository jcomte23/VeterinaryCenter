using VeterinaryCenter.ConsoleApp.Entities;
using VeterinaryCenter.ConsoleApp.Interfaces;

namespace VeterinaryCenter.ConsoleApp.Services;

internal class CustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public void AddCustomer(Customer customer)
    {
        if (_repository.GetAllCustomers()
                       .Any(c => c.DocumentNumber == customer.DocumentNumber))
        {
            throw new InvalidOperationException("Ya existe un cliente con ese documento.");
        }

        _repository.AddCustomer(customer);
    }

    public List<Customer> GetAllCustomers()
    {
        return _repository.GetAllCustomers();
    }

    public Customer? GetCustomerById(Guid id)
    {
        return _repository.GetCustomerById(id);
    }

    public void UpdateCustomer(Customer customer)
    {
        _repository.UpdateCustomer(customer);
    }

    public void DeleteCustomer(Guid id)
    {
        _repository.DeleteCustomer(id);
    }
}

