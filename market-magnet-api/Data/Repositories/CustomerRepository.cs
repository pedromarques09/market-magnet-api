using market_magnet_api.Data.Configurations;
using market_magnet_api.Models;
using MongoDB.Driver;

namespace market_magnet_api.Data.Repositories
{
    
        public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(DataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DatabaseName);
            _customers = database.GetCollection<Customer>("Customers");
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers.Find(customer => true).ToList();
        }

        public IEnumerable<Customer> GetCustomersByUserId(string userId)
        {
            return _customers.Find(customer => customer.UserId == userId).ToList();
        }

        public Customer GetCustomerById(string id)
        {
            return _customers.Find<Customer>(customer => customer._id == id).FirstOrDefault();
        }

        public Customer GetLastCustomer(string userId)
        {
            return _customers.Find<Customer>(customer => customer.UserId == userId).SortByDescending(customer => customer.Codigo).FirstOrDefault();
        }

        public void CreateCustomer(Customer customer)
        {
            _customers.InsertOne(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _customers.ReplaceOne(c => c._id == customer._id, customer);
        }

        public void DeleteCustomer(string id)
        {
            _customers.DeleteOne(customer => customer._id == id);
        }
    }
}
