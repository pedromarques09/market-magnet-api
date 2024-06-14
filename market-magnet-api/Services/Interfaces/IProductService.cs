using market_magnet_api.Models;

namespace market_magnet_api.Services.Interfaces
{


    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByUserId(string userId);
        Product GetProductById(string id);
        Product GetLatestProduct(string userId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        IEnumerable<Product> UpdateStock(Payload payload);
        void DeleteProduct(string id);
    }

}
