using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByUserId(string userId);
        Product GetById(string id);
        void Create(Product product);
        void Update(Product product);
        void Delete(string id);
    }
}
