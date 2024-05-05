﻿using JobBoardsSite.Client.Services;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Client.Pages.Authentication.Login
{
    public partial class Login
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
			[StringLength(30, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
			public string Password { get; set; }

		}

		private async Task  OnValidSubmit(EditContext context)
		{
			success = true;

			var authResponse = await ClientAuthService.Login(new LoginUserRequest(model.Email, model.Password));


			var res =  await ClientAuthService.SignInUser(authResponse);

			var i = res.User.IsInRole("Applicant");
			ClientAuthService.RaiseEventAuthenticationStateChanged(res);

			StateHasChanged();

			NavigationManager.NavigateTo("/");

		}

	}
}
