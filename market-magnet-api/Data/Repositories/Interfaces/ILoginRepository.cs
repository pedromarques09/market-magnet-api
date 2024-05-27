using market_magnet_api.Models;

namespace market_magnet_api.Data.Repositories.Interfaces
{
    public interface ILoginRepository
    {
        User Post(LoginRequest loginRequest);
        void UpdateUser(User user);
        User GetUserByRefreshToken(string refreshToken);
    }
}
