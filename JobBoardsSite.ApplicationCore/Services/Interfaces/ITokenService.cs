using JobBoardsSite.Shared.Entities;

namespace JobBoardsSite.ApplicationCore.Services.Interfaces;

public interface ITokenService
{
	string GenerateToken(ApplicationUser user);
}
