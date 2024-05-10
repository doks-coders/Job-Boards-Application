
using JobBoardsSite.Client.Helpers;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.Recruiter.Job.JobEdit;

public partial class JobEdit
{
	[Parameter]
	public int Id { get; set; }

	[Inject]
	public IClientJobService JobService { get; set; }

	ClientMapperProfiles _mapper = new();
	EditJobRequest EditJobRequest { get; set; } = null;
	protected override async Task OnInitializedAsync()
	{
		var res = await JobService.GetJob(Id);

		EditJobRequest = _mapper.JobItemResponseToEditJobRequest(res);
	}
}
