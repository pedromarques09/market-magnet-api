using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories.Interfaces
{
    public interface IPaymentMethodRepository
    {
        IEnumerable<PaymentMethod> GetAll();
        IEnumerable<PaymentMethod> GetByUserId(string userId);
        PaymentMethod GetById(string id);
        void Create(PaymentMethod paymentMethod);
        void Update(PaymentMethod paymentMethod);
        void Delete(string id);
    }
}
