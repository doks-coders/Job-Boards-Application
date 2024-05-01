using JobBoardsSite.ApplicationCore.Services;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace JobBoardsSite.Api.Extensions
{
    static public class ApplicationServiceExtensions
    {
        static public IServiceCollection ConfigureAppServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<ITokenService, TokenService>();
			return services; 
        }
    }
}
