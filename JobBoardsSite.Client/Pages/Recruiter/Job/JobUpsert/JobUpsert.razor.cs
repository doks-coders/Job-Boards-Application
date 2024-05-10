using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Client.Helpers;

namespace JobBoardsSite.Client.Pages.Recruiter.Job.JobUpsert
{
	public partial class JobUpsert
	{
		[Inject]
		IClientJobService JobService { get; set; }

		[Inject]
		NavigationManager NavigationManager { get; set; }

		[Parameter]
		public EditJobRequest EditJobRequest { get; set; }

		public string WorkLocation { get; set; }

		CreateJobRequest model = new CreateJobRequest();
		ClientMapperProfiles _mapper = new();

		bool success;

		[Parameter]
		public string FormType { get; set; } = "create";


		protected override async Task OnInitializedAsync()
		{
			if (EditJobRequest != null)
			{
				model = _mapper.EditJobRequestToCreateJobRequest(EditJobRequest);
			}

		}

		private async Task OnValidSubmit(EditContext context)
		{
			success = true;
			StateHasChanged();

			if (FormType == "create")
			{
				await JobService.CreateJob(model);
			}
			if (FormType == "edit")
			{
				var editRequest = _mapper.CreateJobRequestToEditJobRequest(model);
				editRequest.Id = EditJobRequest.Id;
				await JobService.EditJob(editRequest);
			}

			NavigationManager.NavigateTo("/recruiter-admin-homepage");
		}
	}
}
