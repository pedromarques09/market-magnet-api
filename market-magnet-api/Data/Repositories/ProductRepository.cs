using market_magnet_api.Data.Configurations;
using market_magnet_api.Models;
using MongoDB.Driver;

namespace market_magnet_api.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(DataBaseConfig DataBaseConfig)
        {
            var client = new MongoClient(DataBaseConfig.ConnectionString);
            var database = client.GetDatabase(DataBaseConfig.DatabaseName);

            _products = database.GetCollection<Product>("Products");
        }

        public IEnumerable<Product> GetAll()
        {
            return _products.Find(product => true).ToList();
        }
        public IEnumerable<Product> GetByUserId(string userId)
        {
            return _products.Find(product => product.UserId == userId).ToList();
        }

        public Product GetById(string id)
        {
            return _products.Find<Product>(product => product._id == id).FirstOrDefault();
        }

        public void Create(Product product)
        {   
            _products.InsertOne(product);
        }

        public void Update(Product product)
        {
            _products.ReplaceOne(p => p._id == product._id, product);
        }

        public void Delete(string id)
        {
            _products.DeleteOne(product => product._id == id);
        }
    }
}
