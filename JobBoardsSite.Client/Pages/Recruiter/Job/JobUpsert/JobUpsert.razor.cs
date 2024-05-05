using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using JobBoardsSite.Client.Services.Interfaces;

namespace JobBoardsSite.Client.Pages.Recruiter.Job.JobUpsert
{
	public partial class JobUpsert
	{
		[Inject]
		IJobService JobService { get; set; }

		[Inject]
		NavigationManager NavigationManager { get; set; }

		public string WorkLocation { get; set; }
		CreateJobRequest model = new CreateJobRequest();


		bool success;

		[Parameter]
		public string FormType { get; set; } = "create";



		private async Task OnValidSubmit(EditContext context)
		{
			success = true;
			StateHasChanged();
			var res =  await JobService.CreateJob(model);

			NavigationManager.NavigateTo("/recruiter-admin-homepage");
		}
	}
}
