using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserById(string id);
        User GetUserByEmail(string email);
        User CreateUser(User user);
        User UpdateUser(User user);
        void DeleteUser(string id);
        void UpdateFields(string id, Dictionary<string, string> fields);
    }
}
