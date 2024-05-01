using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services
{
	public class TokenService:ITokenService
	{
		private readonly SymmetricSecurityKey _symmetric;
		private readonly JwtOptions _options;

		public TokenService(IOptions<JwtOptions> options)
		{
			
			_options = options.Value;
			_symmetric = new( Encoding.UTF8.GetBytes(_options.Secret));
		}

		public string GenerateToken(ApplicationUser user)
		{
			List<Claim> Claims = new()
			{
				new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
				new Claim(ClaimTypes.Email,user.Email),
				new Claim(ClaimTypes.Role,"Applicant")
			};

			var claimsIdentity = new ClaimsIdentity(Claims);

			var signInCred = new SigningCredentials(_symmetric, SecurityAlgorithms.HmacSha256Signature);

			var tokenDescriptor = new SecurityTokenDescriptor()
			{
				SigningCredentials = signInCred,
				Subject = claimsIdentity,
				Audience = _options.Audience,
				Issuer = _options.Issuer
			};

			var handler = new JwtSecurityTokenHandler();
			var token = handler.CreateToken(tokenDescriptor);

			return handler.WriteToken(token);
			
			
			
		}





	}
}
