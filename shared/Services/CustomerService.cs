using shared.Entities;
using shared.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace shared.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly AddressService _addressService;

    public CustomerService(CustomerRepository customerRepository, AddressService addressService)
    {
        _customerRepository = customerRepository;
        _addressService = addressService;
    }

    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string streetName, string postalCode, string city)
    {
        try
        {
            var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);

            var customerEntity = _customerRepository.Create(new CustomerEntity
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                AddressId = addressEntity.Id,
            });

            if (customerEntity != null)
            {
                return customerEntity;
            }
            
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CustomerEntity GetCustomerByEmail(string email)
    {
        try
        {
            var customerEntity = _customerRepository.GetOne(x => x.Email == email);
            if (customerEntity != null)
            {
                return customerEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        try
        {
            var customerEntity = _customerRepository.GetOne(x => x.Id == id);
            if (customerEntity != null)
            {
                return customerEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public IEnumerable<CustomerEntity> GetCustomers()
    {
        try
        {
            var customers = _customerRepository.GetAll();
            if (customers != null)
            {
                return customers;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity CustomerEntity)
    {
        try
        {
            var customerEntityToUpdate = _customerRepository.Update(x => x.Id == CustomerEntity.Id, CustomerEntity);
            if (customerEntityToUpdate != null)
            {
                return customerEntityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteCustomer(string email)
    {
        try
        {
            var customerEntity = _customerRepository.GetOne(x => x.Email == email);
            if (customerEntity != null)
            {
                _customerRepository.Delete(x => x.Email == email);
                return true;
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }
}
