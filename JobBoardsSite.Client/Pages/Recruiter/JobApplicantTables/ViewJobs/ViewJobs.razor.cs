using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.Recruiter.JobApplicantTables.ViewJobs
{
	public partial class ViewJobs
	{

		[Inject]
		IClientRecruiterService ClientRecruiterService { get; set; }
		private bool dense = false;
		private bool canCancelEdit = false;
		private string searchString = "";
		private JobItemTableResponse selectedItem1 = null;
		private IEnumerable<JobItemTableResponse> Elements = new List<JobItemTableResponse>();



		protected override async Task OnInitializedAsync()
		{
			Elements = await ClientRecruiterService.GetJobsTable();
		}



		private bool FilterFunc(JobItemTableResponse element)
		{
			if (string.IsNullOrWhiteSpace(searchString))
				return true;
			if (element.ContactEmail.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if (element.JobTitle.Contains(searchString, StringComparison.OrdinalIgnoreCase))
				return true;
			if ($"{element.ContactEmail} {element.JobTitle}".Contains(searchString))
				return true;
			return false;
		}
	}
}
