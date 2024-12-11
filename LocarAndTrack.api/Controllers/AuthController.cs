using LocarAndTrack.api.Data;
using LocarAndTrack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace LocarAndTrack.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApiContext _context;
        public AuthController(IConfiguration configuration, ApiContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        private string CreateToken(Cliente user)
        {
            List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.CPF),
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim(ClaimTypes.Role, user.Perfil.RoleName),
                    new Claim(ClaimTypes.Email, user.Email)
                };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("Jwt:SecretKey").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(ClienteLogin login)
        {
            var user = await _context.Clientes.Include(f => f.Perfil)
                                        .FirstOrDefaultAsync(f => f.Email == login.Email);
            if (user == null)
            {
                return NotFound("Email incorreto.");
            }
            if (!VerifyPasswordHash(login.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Email ou Senha incorreto.");
            }

            var token = CreateToken(user);

            var perfil = await _context.Perfis.FindAsync(user.PerfilId);

            var Cliente = new ClienteDto
            {
                CPF = user.CPF,
                Nome = user.Nome,
                Email = user.Email,
                Telefone = user.Telefone,
                Role = perfil.RoleName,
                Token = token,
                PerfilId = user.PerfilId
            };

            return Ok(Cliente);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var cliente = new Cliente
            {
                CPF = request.CPF,
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone,
                PerfilId = request.PerfilId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = "user"
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
