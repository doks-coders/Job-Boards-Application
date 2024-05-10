

using JobBoardsSite.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobBoardsSite.Client.Helpers;
public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
	private readonly IManageLocalStorage _manageLocalStorage;


	public CustomAuthenticationStateProvider(IManageLocalStorage manageLocalStorage)
	{
		_manageLocalStorage = manageLocalStorage;
	}

	public override async Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		// Implement logic to retrieve authentication state from cookies, JWT tokens, etc.
		// For example, you might check if the user has a valid session and return the corresponding ClaimsPrincipal.
		// Here's a simplified example assuming the user is always authenticated as an admin:

		var authUser = await _manageLocalStorage.GetUserFromLocalStorage();
		if (authUser == null)
		{
			var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
			return await Task.FromResult(new AuthenticationState(anonymousUser));
		}


		var handler = new JwtSecurityTokenHandler();

		var jwt = handler.ReadJwtToken(authUser.Token);
		var identity = new ClaimsIdentity();

		var id = jwt.Claims?.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.NameId)?.Value;
		var email = jwt.Claims?.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email)?.Value;
		var role = jwt.Claims?.FirstOrDefault(u => u.Type == "role")?.Value;

		identity.AddClaims(
			//add claims here
			new List<Claim>() {
				new Claim(ClaimTypes.NameIdentifier, id),
				new Claim(ClaimTypes.Email, email),
				new Claim(ClaimTypes.Role, role)
				}
			);

		var user = new ClaimsPrincipal(identity);


		return await Task.FromResult(new AuthenticationState(user));
	}

	// Implement methods to update authentication state if needed
	// For example, you might have methods to set the authentication state when a user logs in or logs out.
}
