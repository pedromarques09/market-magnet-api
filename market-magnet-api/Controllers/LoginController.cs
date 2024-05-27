using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using market_magnet_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace market_magnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService, ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest loginRequest)
        {
            var user = _loginRepository.Post(loginRequest);
            if (user == null)
            {
                return NotFound();
            }

            var token = _authService.GenerateJwtToken(user);
            var refreshToken = _authService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            _loginRepository.UpdateUser(user);

            return Ok(new
            {
                User = user,
                Token = token,
                RefreshToken = refreshToken
            });
        }

        [HttpPost("refresh")]
        public IActionResult Refresh([FromBody] RefreshTokenRequest refreshTokenRequest)
        {
            var user = _loginRepository.GetUserByRefreshToken(refreshTokenRequest.RefreshToken);
            if (user == null || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return Unauthorized();
            }

            var newToken = _authService.GenerateJwtToken(user);
            var newRefreshToken = _authService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            _loginRepository.UpdateUser(user);

            return Ok(new
            {
                Token = newToken,
                RefreshToken = newRefreshToken
            });
        }
    }
}
