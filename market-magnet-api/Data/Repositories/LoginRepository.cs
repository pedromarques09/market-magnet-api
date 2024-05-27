using market_magnet_api.Data.Configurations;
using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using MongoDB.Driver;

namespace market_magnet_api.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IMongoCollection<User> _users;

        public LoginRepository(DataBaseConfig DataBaseConfig)
        {
            var client = new MongoClient(DataBaseConfig.ConnectionString);
            var database = client.GetDatabase(DataBaseConfig.DatabaseName);

            _users = database.GetCollection<User>("Users");
        }

        public User Post(LoginRequest loginRequest)
        {
            return _users.Find(user => user.Email == loginRequest.Email && user.Password == loginRequest.Password).FirstOrDefault();
        }

        public void UpdateUser(User user)
        {
            _users.ReplaceOne(u => u._id == user._id, user);
        }

        public User GetUserByRefreshToken(string refreshToken)
        {
            return _users.Find(user => user.RefreshToken == refreshToken).FirstOrDefault();
        }
    }
}
