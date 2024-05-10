using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Constants;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace JobBoardsSite.Client.Pages;

public partial class JobsPage
{
	[Inject]
	private NavigationManager NavigationManager { get; set; }

	[Inject]
	public IClientAuthService ClientAuthService { get; set; }

	[Inject]
	public IClientJobService JobService { get; set; }

	public List<JobListItemResponse> JobList { get; set; } = new();

	private string Country { get; set; } = "All";
	public string SelectedSkills { get; set; } = "All";
	public string WorkType { get; set; } = "All";

	private int _selected = 1;
	private int _total = 4;


	protected async Task RetrievePage()
	{

		var value = await JobService.GetJobsPagination(new()
		{
			PageLimit = 3,
			PageNumber = _selected,
			Skills = string.IsNullOrEmpty(SelectedSkills) ? "All" : SelectedSkills,
			Country = string.IsNullOrEmpty(Country) ? "All" : Country,
			WorkType = string.IsNullOrEmpty(WorkType) ? "All" : WorkType,
		});

		_total = value.TotalPages;
		_selected = value.PageNumber;

		var obj = value.Items as JArray;
		var data = obj.ToObject<List<JobListItemResponse>>();
		JobList = data;
	}

	protected override async Task OnInitializedAsync()
	{
		if (ClientAuthService.AuthenticationState.User.IsInRole(RoleConstants.Recruiter))
		{
			NavigationManager.NavigateTo("/recruiter-admin-homepage");
		}

		await RetrievePage();
	}

}
