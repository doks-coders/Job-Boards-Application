using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace JobBoardsSite.Client.Pages
{
	public partial class JobsPage
	{
		[Inject]
		public IClientAuthService ClientAuthService { get; set; }

		[Inject]
		public IJobService JobService { get; set; }

		public List<JobListItemResponse> JobList { get; set; } = new();

		private int _selected = 1;

		private int _total = 4;

		protected async Task RetrievePage()
		{
			var value = await JobService.GetJobsPagination(new() { PageNumber = _selected });

			_total = value.TotalPages;
			_selected = value.PageNumber;

			var obj = value.Items as JArray;
			var data = obj.ToObject<List<JobListItemResponse>>();
			JobList = data;
		}

		protected override async Task OnInitializedAsync()
		{
			await RetrievePage();

			//JobList = await JobService.GetJobs();

			
			/*
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
			*/
		}



	}
}
