using market_magnet_api.Data.Repositories;
using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;

namespace market_magnet_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public IEnumerable<Product> GetProductsByUserId(string userId)
        {
            return _productRepository.GetByUserId(userId);
        }

        public Product GetProductById(string id)
        {
            return _productRepository.GetById(id);
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(string id)
        {
            _productRepository.Delete(id);
        }
    }
}
