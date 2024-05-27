using market_magnet_api.Models;
using System.Collections.Generic;

namespace market_magnet_api.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> GetCustomersByUserId(string userId);
        Customer GetCustomerById(string id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}
