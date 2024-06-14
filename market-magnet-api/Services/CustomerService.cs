using market_magnet_api.Data.Repositories;
using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;

namespace market_magnet_api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public IEnumerable<Customer> GetCustomersByUserId(string userId)
        {
            return _customerRepository.GetCustomersByUserId(userId);
        }

        public Customer GetCustomerById(string id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        public Customer GetLastCustomer(string userId)
        {
            return _customerRepository.GetLastCustomer(userId);
        }

        public void CreateCustomer(Customer customer)
        {
            _customerRepository.CreateCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(string id)
        {
            _customerRepository.DeleteCustomer(id);
        }
    }
}
