using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sharing.DataAccessCore.Core;
using Sharing.DataAccessCore.Interfaces;
using Sharing.Domain;

namespace Sharing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }

        [HttpPost("registerAsLessor")]
        public async Task<IActionResult> RegisterAsLessor(UserForRegisterDto userForRegisterDto)
        {
            //validate request

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if(await _authRepository.LessorExists(userForRegisterDto.Username))
            {
                return BadRequest("Username alrady exists");
            }

            var userToCreate = new Lessor()
            {
                UserName = userForRegisterDto.Username
            };

            var createdUser = await _authRepository.RegisterAsLessor(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("registerAsRenter")]
        public async Task<IActionResult> RegisterAsRenter(UserForRegisterDto userForRegisterDto)
        {
            //validate request

            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _authRepository.RenterExists(userForRegisterDto.Username))
            {
                return BadRequest("Username alrady exists");
            }

            var userToCreate = new Renter()
            {
                UserName = userForRegisterDto.Username
            };

            var createdUser = await _authRepository.RegisterAsRenter(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }
        [HttpPost("loginAsRenter")]
        public async Task<IActionResult> LoginAsRenter(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authRepository.LoginAsRenter(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if(userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token),
            userId = userFromRepo.Id});
        }

        [HttpPost("loginAsLessor")]
        public async Task<IActionResult> LoginAsLessor(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _authRepository.LoginAsLessor(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (userFromRepo == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}