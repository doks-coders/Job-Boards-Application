using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace JobBoardsSite.Client.Pages.Recruiter.ViewProspectiveApplicants
{
	public partial class ViewProspectiveApplicants
	{
		public string _normalText { get; set; }
		private string Country { get; set; } = "";
		public string SelectedSkills { get; set; } = "";


		[Inject]
		public IClientAuthService ClientAuthService { get; set; }

		[Inject]
		public IClientApplicantService ApplicantService  { get; set; }

		public List<ApplicantListItem> ApplicantList { get; set; } = new();

		private int _selected = 1;


		private int _total = 4;

		protected async Task RetrievePage()
		{
			var value = await ApplicantService.SearchApplicants(new() { 
				PageNumber = _selected,
				Skills = string.IsNullOrEmpty(SelectedSkills)?"All": SelectedSkills,
				Country = string.IsNullOrEmpty(Country) ? "All" : Country,
			});

			_total = value.TotalPages;
			_selected = value.PageNumber;

			var obj = value.Items as JArray;
			var data = obj.ToObject<List<ApplicantListItem>>();
			ApplicantList = data;
		}

		protected override async Task OnInitializedAsync()
		{
			await RetrievePage();
		}


	}
}
