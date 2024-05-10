using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.Recruiter.RecruiterInformation;

public partial class RecruiterInformation
{
	[Inject]
	IClientRecruiterService ClientRecruiterService { get; set; }

	[Parameter]
	public int Id { get; set; }

	RecruiterResponse Recruiter { get; set; } = null;
	protected override async Task OnInitializedAsync()
	{
		if (Id == 0 || Id == null)
		{
			Recruiter = await ClientRecruiterService.GetMyRecruiterInfo();
		}
		else
		{
			Recruiter = await ClientRecruiterService.GetRecruiterInfo(Id);
		}
	}
}
