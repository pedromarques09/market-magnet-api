using market_magnet_api.Data.Configurations;
using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using MongoDB.Driver;

namespace market_magnet_api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(DataBaseConfig DataBaseConfig)
        {
            var client = new MongoClient(DataBaseConfig.ConnectionString);
            var database = client.GetDatabase(DataBaseConfig.DatabaseName);

            _users = database.GetCollection<User>("Users");
        }

        public IEnumerable<User> GetAll()
        {
            return _users.Find(user => true).ToList();
        }

        public User GetUserById(string id)
        {
            return _users.Find<User>(user => user._id == id).FirstOrDefault();
        }

        public User GetUserByEmail(string email)
        {
            return _users.Find<User>(user => user.Email == email).FirstOrDefault();
        }

        public User CreateUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user._id == id);
        }
        public void UpdateFields(string id, Dictionary<string, string> fields)
        {
            var updateDefinition = new List<UpdateDefinition<User>>();
            foreach (var field in fields)
            {
                updateDefinition.Add(Builders<User>.Update.Set(field.Key, field.Value));
            }
            var update = Builders<User>.Update.Combine(updateDefinition);
            _users.UpdateOne(user => user._id == id, update);
        }


        public User UpdateUser(User user)
        {
            _users.ReplaceOne(user => user._id == user._id, user);
            return user;
        }

     
    }
}
