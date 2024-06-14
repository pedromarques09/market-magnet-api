using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAll();
        IEnumerable<Sale> GetByUserId(string userId);
        Sale GetLastSale(string userId);
        Sale GetById(string id);
        void Create(Sale sale);
        void Update(Sale sale);
        void Delete(string id);
    }
}
