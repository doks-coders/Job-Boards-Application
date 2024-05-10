using JobBoardsSite.Client.Pages.MiscComponents;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Constants;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JobBoardsSite.Client.Pages.Applicant.JobInformation;


public partial class JobInformation
{
	[Parameter]
	public int Id { get; set; }


	[Inject]
	IDialogService DialogService { get; set; }

	[Inject]
	IClientAuthService ClientAuthService { get; set; }

	[Inject]
	IClientJobService JobService { get; set; }

	[Inject]
	NavigationManager NavigationManager { get; set; }

	[Inject]
	IClientApplicantService ApplicantService { get; set; }

	public JobItemResponse? Job { get; set; }


	protected override async Task OnInitializedAsync()
	{

		Job = await JobService.GetJob(Id);

	}


	protected async Task ApplyToJob()
	{
		if (!ClientAuthService.AuthenticationState.User.IsInRole(RoleConstants.Applicant))
		{
			NavigationManager.NavigateTo("/login");
		}
		else
		{
			var res = await ApplicantService.JobApply(Job.Id);
			var parameters = new DialogParameters<SimpleDialog>();
			parameters.Add(x => x.ContentText, res.Message);

			var options = new DialogOptions { CloseOnEscapeKey = true, };
			DialogService.Show<SimpleDialog>("Job Application", parameters);
		}

	}
}
