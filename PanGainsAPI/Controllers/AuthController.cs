using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PanGainsAPI.Data;
using PanGainsAPI.Models;
using StreamChat.Clients;
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
            account.Firstname = request.Firstname;
            account.Lastname = request.Lastname;
            account.Email = request.Email;
            account.Private = false;
            account.Notifications = false;
            account.AverageChallengePos = 0;
            account.Type = "";
            account.Role = "Account";
            account.Password = request.Password;
            account.MessageToken = getToken(account);

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

        private string? getToken(Account account)
        {
            var factory = new StreamClientFactory("u4ycx472g2x3", "dbk3mmd7hvebwzefnnwpnhe6f2wcfbhvnnvf95p4qtacx9un29bbjbyyvngd6hdc");
            var userClient = factory.GetUserClient();

            return userClient.CreateToken($"{account.Firstname}-{account.Lastname}");
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
            if (account.Password != request.Password)
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
                new Claim(ClaimTypes.GivenName, account.Firstname),
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
    }

}

