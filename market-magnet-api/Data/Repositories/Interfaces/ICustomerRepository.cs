using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> GetCustomersByUserId(string userId);
        Customer GetCustomerById(string id);
        Customer GetLastCustomer(string userId);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}
