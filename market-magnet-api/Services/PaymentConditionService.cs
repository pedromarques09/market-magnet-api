using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;

namespace market_magnet_api.Services
{
    public class PaymentConditionService : IPaymentConditionService
    {
        private readonly IPaymentConditionRepository _paymentConditionRepository;

        public PaymentConditionService(IPaymentConditionRepository paymentConditionRepository)
        {
            _paymentConditionRepository = paymentConditionRepository;
        }

        public IEnumerable<PaymentCondition> GetAllPaymentConditions()
        {
            return _paymentConditionRepository.GetAll();
        }

        public IEnumerable<PaymentCondition> GetPaymentConditionsByUserId(string userId)
        {
            return _paymentConditionRepository.GetByUserId(userId);
        }

        public PaymentCondition GetPaymentConditionById(string id)
        {
            return _paymentConditionRepository.GetById(id);
        }

        public void CreatePaymentCondition(PaymentCondition paymentCondition)
        {
            _paymentConditionRepository.Create(paymentCondition);
        }

        public void UpdatePaymentCondition(PaymentCondition paymentCondition)
        {
            _paymentConditionRepository.Update(paymentCondition);
        }

        public void DeletePaymentCondition(string id)
        {
            _paymentConditionRepository.Delete(id);
        }
    }
}
