using market_magnet_api.Data.Configurations;
using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using MongoDB.Driver;

namespace market_magnet_api.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IMongoCollection<Sale> _sales;

        public SaleRepository(DataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DatabaseName);

            _sales = database.GetCollection<Sale>("Sale");
        }

        public IEnumerable<Sale> GetAll()
        {
           return _sales.Find(sale => true).ToList();
        }
        public IEnumerable<Sale> GetByUserId(string userId)
        {
            return _sales.Find(sale => sale.UserId == userId).ToList();
        }

        public Sale GetLastSale(string userId)
        {
            return _sales.Find<Sale>(sale => sale.UserId == userId).SortByDescending(sale => sale.Codigo).FirstOrDefault();
        }

        public Sale GetById(string id)
        {
            return _sales.Find<Sale>(sale => sale._id == id).FirstOrDefault();
        }

        public void Create(Sale sale) 
        {
            _sales.InsertOne(sale);
        }
        public void Update(Sale sale)
        {
            _sales.ReplaceOne(s => s._id == sale._id, sale);
        }

        public void Delete(string id)
        {
            _sales.DeleteOne(sale => sale._id == id);
        }
    }
}
