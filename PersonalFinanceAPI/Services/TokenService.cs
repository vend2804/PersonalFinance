using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace PersonalFinanceAPI.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;

        }

        public string CreateToken(AppUser user)
        {

            //Create Claims
            var claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Email, user.Email),

            };

            // Create the Key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));

            // Create the Credentials
            var creds =  new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

                // create Token descriptor

            var tokenDecriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires= DateTime.UtcNow.AddDays(7),
            SigningCredentials = creds

            };
            // Initialize Token Handler

            var tokenHandler =new JwtSecurityTokenHandler();

            // Create Token
            var token = tokenHandler.CreateToken(tokenDecriptor);

            return tokenHandler.WriteToken(token);

        }

    }
}