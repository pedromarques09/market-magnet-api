using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;

namespace market_magnet_api.Services
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            return _paymentMethodRepository.GetAll();
        }

        public IEnumerable<PaymentMethod> GetByUserId(string userId)
        {
            return _paymentMethodRepository.GetByUserId(userId);
        }

        public PaymentMethod GetById(string id)
        {
            return _paymentMethodRepository.GetById(id);
        }

        public void Create(PaymentMethod paymentMethod)
        {
            _paymentMethodRepository.Create(paymentMethod);
        }

        public void Update(PaymentMethod paymentMethod)
        {
            _paymentMethodRepository.Update(paymentMethod);
        }

        public void Delete(string id)
        {
            _paymentMethodRepository.Delete(id);
        }
    }
}
