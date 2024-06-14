using market_magnet_api.Models;

namespace market_magnet_api.Services.Interfaces
{
    public interface IPaymentConditionService
    {
        IEnumerable<PaymentCondition> GetAllPaymentConditions();
        IEnumerable<PaymentCondition> GetPaymentConditionsByUserId(string userId);
        PaymentCondition GetPaymentConditionById(string id);
        void CreatePaymentCondition(PaymentCondition paymentCondition);
        void UpdatePaymentCondition(PaymentCondition paymentCondition);
        void DeletePaymentCondition(string id);
    }
}
