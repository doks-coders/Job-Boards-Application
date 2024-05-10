using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.Recruiter.JobApplicantTables.ViewApplicants;

public partial class ViewApplicants
{
	[Inject]
	IClientRecruiterService ClientRecruiterService { get; set; }
	private bool dense = false;
	private bool canCancelEdit = false;
	private string searchString = "";
	private ApplicantsTableResponse selectedItem1 = null;
	private IEnumerable<ApplicantsTableResponse> Elements = new List<ApplicantsTableResponse>();



	protected override async Task OnInitializedAsync()
	{
		Elements = await ClientRecruiterService.GetApplicantsTable();
	}



	private bool FilterFunc(ApplicantsTableResponse element)
	{
		if (string.IsNullOrWhiteSpace(searchString))
			return true;
		if (element.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase))
			return true;
		if (element.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
			return true;
		if ($"{element.Name} {element.Email} {element.JobTitle}".Contains(searchString))
			return true;
		return false;
	}
}
