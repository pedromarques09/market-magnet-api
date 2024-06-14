using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories.Interfaces
{
    public interface IPaymentConditionRepository
    {
        IEnumerable<PaymentCondition> GetAll();
        IEnumerable<PaymentCondition> GetByUserId(string userId);
        PaymentCondition GetById(string id);
        void Create(PaymentCondition paymentCondition);
        void Update(PaymentCondition paymentCondition);
        void Delete(string id);
    }
}
