using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.Recruiter.ModifyRecruiterInformation.EditRecruiterInformation
{
	public partial class EditRecruiterInformation
	{
		[Inject]
		IClientRecruiterService RecruiterService { get; set; }
		RecruiterResponse Recruiter = null;

		protected override async Task OnInitializedAsync()
		{
			Recruiter = await RecruiterService.GetMyRecruiterInfo();
		}
	}
}
