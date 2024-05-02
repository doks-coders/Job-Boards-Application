using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages
{
	public partial class JobsPage
	{
		[Inject]
		public IClientAuthService ClientAuthService { get; set; }

		public List<JobListItemResponse> JobList { get; set; }

		
		protected override async Task OnInitializedAsync()
		{
			JobList = new()
			{
				new JobListItemResponse()
				{
					CompanyImageUrl="",
					CompanyName="Daniel Company",
					JobTitle="Backend Developer",
					SelectedSkills="Javascript||HTML||CSS||Python",
					WorkLocationType="Remote||Onsite",
					Salary="1000"

				}
			};
		}



	}
}
