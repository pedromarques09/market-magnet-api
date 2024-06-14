using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserById(string id);
        User GetUserByEmail(string email);
        User CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(string id);
    }
}
