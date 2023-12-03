

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace BookClubApp.Business.Services
{
    public class AuthService : IAuthService
    {
        public string GenerateJwtToken()
        {
            var secretKey = Encoding.UTF8.GetBytes("E7x32Fm8Vd1D9kGY4TpJrY/+y4/RNywu/I78mY+p+28="); //TODO: generate new, and put in secure place after testing

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            Console.WriteLine($"Generated JWT token: {token}");
            return tokenHandler.WriteToken(token);
        }
    }
}