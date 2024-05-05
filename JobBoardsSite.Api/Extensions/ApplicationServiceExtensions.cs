using JobBoardsSite.ApplicationCore.Services;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Data;
using JobBoardsSite.Infrastructure.Repositories;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobBoardsSite.Api.Extensions
{
    static public class ApplicationServiceExtensions
    {
        static public IServiceCollection ConfigureAppServices(this IServiceCollection services,IConfiguration config)
        {
            services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJobService, JobService>();
			services.AddScoped<IApplicantService, ApplicantService>();
			services.AddScoped<IRecruiterService, RecruiterService>();
			return services; 
        }
    }
}
