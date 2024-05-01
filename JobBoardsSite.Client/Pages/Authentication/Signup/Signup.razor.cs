using JobBoardsSite.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace JobBoardsSite.Client.Pages.Authentication.Signup
{
    public partial class Signup
    {
		[Inject]
		IClientAuthService ClientAuthService { get; set; }

		[Inject]
		NavigationManager NavigationManager { get; set; }



		RegisterAccountForm model = new RegisterAccountForm();
		bool success;

		public class RegisterAccountForm
		{
			[Required]
			public string Name { get; set; }

			[Required]
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			[StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
			public string Password { get; set; }

			[Required]
			[Compare(nameof(Password))]
			public string Verify { get; set; }

		}

		private async Task OnValidSubmit(EditContext context)
		{
			success = true;
			StateHasChanged();

			var authResponse = await ClientAuthService.Register(new(model.Name,model.Email,model.Password,model.Verify));
			var res =  await ClientAuthService.SignInUser(authResponse);

			ClientAuthService.RaiseEventAuthenticationStateChanged(res);
			//var isAuthenticated = res.User.Identity.IsAuthenticated;
			NavigationManager.NavigateTo("/");



		}
	}
}
