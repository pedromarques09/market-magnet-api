using market_magnet_api.Data.Repositories.Interfaces;
using market_magnet_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace market_magnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/<UserController>s
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userRepository.GetAll();
            return Ok(users);  
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(string id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public IActionResult Post([FromBody] User newUser)
        {
            try
            {
                // Verifica se o e-mail já está sendo utilizado
                var existingUser = _userRepository.GetUserByEmail(newUser.Email);
                if (existingUser != null)
                {
                    return Conflict("E-mail já está sendo utilizado por outro usuário.");
                }

                // Cria o novo usuário sem definir RefreshToken e RefreshTokenExpiryTime
                var user = new User(newUser.Name, newUser.Email, newUser.Password);
                _userRepository.CreateUser(user);

                return CreatedAtAction(nameof(GetUserById), new { id = user._id }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno do servidor: " + ex.Message);
            }
        }
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] Dictionary<string, string> fields)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                _userRepository.UpdateFields(id, fields);
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }
        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                _userRepository.DeleteUser(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
