using market_magnet_api.Models;

namespace market_magnet_api.Services.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetSales();
        IEnumerable<Sale> GetSalesByUserId(string userId);
        Sale GetLastSale(string userId);
        Sale GetSaleById(string id);
        void CreateSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(string id);
    }
}
