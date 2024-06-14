using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;

namespace market_magnet_api.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public IEnumerable<Sale> GetSales()
        {
            return _saleRepository.GetAll();
        }
        public Sale GetLastSale(string userId)
        {
            return _saleRepository.GetLastSale(userId);
        }   

        public IEnumerable<Sale> GetSalesByUserId(string userId)
        {
            return _saleRepository.GetByUserId(userId);
        }

        public Sale GetSaleById(string id)
        {
            return _saleRepository.GetById(id);
        }

        public void CreateSale(Sale sale)
        {
            _saleRepository.Create(sale);
        }

        public void UpdateSale(Sale sale)
        {
            _saleRepository.Update(sale);
        }

        public void DeleteSale(string id)
        {
            _saleRepository.Delete(id);
        }
    }
}
