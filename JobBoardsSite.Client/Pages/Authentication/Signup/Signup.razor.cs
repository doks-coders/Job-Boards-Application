using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Constants;
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
			[EmailAddress]
			public string Email { get; set; }

			[Required]
			public string UserType { get; set; }

			[Required]
			[StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
			public string Password { get; set; } = "Password1234&";

			[Required]
			[Compare(nameof(Password))]
			public string Verify { get; set; } = "Password1234&";

		}

		private async Task OnValidSubmit(EditContext context)
		{
			success = true;
			StateHasChanged();

			var authResponse = await ClientAuthService.Register(new(model.Email,model.UserType,model.Password,model.Verify));
			var res =  await ClientAuthService.SignInUser(authResponse);

			ClientAuthService.RaiseEventAuthenticationStateChanged(res);
			//var isAuthenticated = res.User.Identity.IsAuthenticated;
			if (model.UserType == RoleConstants.Applicant)
			{
				NavigationManager.NavigateTo("/create-applicant-info");
			}
			if (model.UserType == RoleConstants.Recruiter)
			{
				NavigationManager.NavigateTo("/create-recruiter-information");
			}




		}
	}
}
