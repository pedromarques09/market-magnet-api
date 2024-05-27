using market_magnet_api.Models;

namespace market_magnet_api.Services.Interfaces

{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();
        IEnumerable<Customer> GetCustomersByUserId(string userId);
        Customer GetCustomerById(string id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}
