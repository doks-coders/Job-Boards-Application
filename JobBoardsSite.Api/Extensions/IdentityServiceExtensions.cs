using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Shared.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace JobBoardsSite.Api.Extensions;

public static class IdentityServiceExtensions
{
	public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration config)
	{
		services.AddDbContext<AppIdentityDbContext>(options => options.UseSqlServer(config.GetConnectionString("IdentityConnection")));

		services.AddIdentityCore<ApplicationUser>(e =>
		{
			e.Password.RequireNonAlphanumeric = false;
			e.Password.RequireLowercase = false;
			e.Password.RequireUppercase = false;
			e.Password.RequiredLength = 6;
		}).AddRoles<AppRole>()
		.AddRoleManager<RoleManager<AppRole>>()
		.AddEntityFrameworkStores<AppIdentityDbContext>();


		services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters()
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["ApiSettings:JwtOptions:Secret"])),
				ValidateIssuer = false,
				ValidateAudience = false

			};
		});
		return services;
	}
}
