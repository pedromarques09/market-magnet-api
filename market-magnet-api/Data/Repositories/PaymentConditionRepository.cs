using market_magnet_api.Data.Configurations;
using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using MongoDB.Driver;

namespace market_magnet_api.Data.Repositories
{
    public class PaymentConditionRepository : IPaymentConditionRepository
    {
        private readonly IMongoCollection<PaymentCondition> _paymentConditions;

        public PaymentConditionRepository(DataBaseConfig dataBaseConfig)
        {
            var client = new MongoClient(dataBaseConfig.ConnectionString);
            var database = client.GetDatabase(dataBaseConfig.DatabaseName);

            _paymentConditions = database.GetCollection<PaymentCondition>("PaymentCondition");
        }

        public IEnumerable<PaymentCondition> GetAll()
        {
            return _paymentConditions.Find(paymentCondition => true).ToList();
        }

        public IEnumerable<PaymentCondition> GetByUserId(string userId)
        {
            return _paymentConditions.Find(paymentCondition => paymentCondition.UserId == userId).ToList();
        }

        public PaymentCondition GetById(string id)
        {
            return _paymentConditions.Find<PaymentCondition>(paymentCondition => paymentCondition._id == id).FirstOrDefault();
        }
           

        public void Create(PaymentCondition paymentCondition) =>
            _paymentConditions.InsertOne(paymentCondition);

        public void Update(PaymentCondition paymentCondition) =>
            _paymentConditions.ReplaceOne(
                paymentCondition => paymentCondition._id == paymentCondition._id,
                paymentCondition
            );

        public void Delete(string id) =>
            _paymentConditions.DeleteOne(paymentCondition => paymentCondition._id == id);
    }
}
