using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.Recruiter.RecruiterAdmin
{
	public partial class RecruiterAdminHomepage
	{
		[Inject]
		IClientRecruiterService ClientRecruiterService { get; set; }
		

		private List<JobItemTableResponse> JobItems = new List<JobItemTableResponse>();

		private List<ApplicantsTableResponse> Applicants = new List<ApplicantsTableResponse>();
		protected override async Task OnInitializedAsync()
		{

			Applicants = await ClientRecruiterService.GetApplicantsTable();

			JobItems = await ClientRecruiterService.GetJobsTable();

		}
	}
}
