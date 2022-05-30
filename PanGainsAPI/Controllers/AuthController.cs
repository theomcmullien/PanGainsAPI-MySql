using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PanGainsAPI.Data;
using PanGainsAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PanGainsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly PanGainsAPIContext context;

        public AuthController(IConfiguration configuration, PanGainsAPIContext context)
        {
            this.configuration = configuration;
            this.context = context;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<Account>> Register(AccountAuth request) {
            Account account = new Models.Account();
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
            account.Firstname = request.Firstname;
            account.Lastname = request.Lastname;
            account.Email = request.Email;
            account.Private = false;
            account.Notifications = false;
            account.AverageChallengePos = 0;
            account.Type = "";
            account.Role = "Account";
            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;

            context.Account.Add(account);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return Ok(account);
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> Login(Login request)
        {
            //search for user
            var account = context.Account.FirstOrDefault(u => u.Email == request.Email);
            if (account == null)
            {
                return BadRequest("User not found");
            }
            if (!VerifyPasswordHash(request.Password, account.PasswordHash, account.PasswordSalt))
            {
                return BadRequest("Wrong Password");
            }
            string token = CreateToken(account);
            return Ok(token);
        }

        private string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {

                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role),
            };
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }

}

