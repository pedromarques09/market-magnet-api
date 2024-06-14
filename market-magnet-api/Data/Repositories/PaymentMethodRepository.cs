using market_magnet_api.Data.Configurations;
using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using MongoDB.Driver;

namespace market_magnet_api.Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly IMongoCollection<PaymentMethod> _paymentMethods;

        public PaymentMethodRepository(DataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DatabaseName);

            _paymentMethods = database.GetCollection<PaymentMethod>("PaymentMethod");
        }

        public IEnumerable<PaymentMethod> GetAll()
        {
            return _paymentMethods.Find(paymentMethod => true).ToList();
        }

        public IEnumerable<PaymentMethod> GetByUserId(string userId)
        {
            return _paymentMethods.Find(paymentMethods => paymentMethods.UserId == userId).ToList();
        }

        public PaymentMethod GetById(string id)
        {
            return _paymentMethods.Find<PaymentMethod>(paymentMethod => paymentMethod._id == id).FirstOrDefault();
        }

        public void Create(PaymentMethod paymentMethod)
        {
            _paymentMethods.InsertOne(paymentMethod);
        }

        public void Update(PaymentMethod paymentMethod)
        {
            _paymentMethods.ReplaceOne(p => p._id == paymentMethod._id, paymentMethod);
        }

        public void Delete(string id)
        {
            _paymentMethods.DeleteOne(paymentMethod => paymentMethod._id == id);
        }
    }
}
