using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using INCHE.Producto.Application.External.GetTokenJwt;
using INCHE.Producto.Application.DataBase.User.Commands.AuthUser;

namespace INCHE.Producto.External.GetTokenJwt
{
    public class GetTokenJwtService: IGetTokenJwtService
    {
        private readonly IConfiguration _configuration;
        public GetTokenJwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public string Execute(AuthUserModel model)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			string key = _configuration["SecretKeyJwt"] ?? "sZOCoUYcJJYwk1EJIcKR5zCWmi5iSvcs";
			var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, model.UserName)
			};

			if (!string.IsNullOrEmpty(model.UserName))
				claims.Add(new Claim(ClaimTypes.Name, model.UserName));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddMinutes(30),
				SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256Signature),
				Issuer = _configuration["IssuerJwt"] ?? "miapi",
				Audience = _configuration["AudienceJwt"] ?? "miapiusuarios"
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			var tokenString = tokenHandler.WriteToken(token);
			return tokenString;
		}
	}
}