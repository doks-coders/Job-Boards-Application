using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;

namespace JobBoardsSite.Client.Pages.Applicant.ModifyApplicantInformation.UpsertApplicantInfo;

public partial class UpsertApplicantInfo
{

	ApplicantProfileRequest model = new ApplicantProfileRequest();
	List<WorkExperience> WorkExperiences { get; set; } = new();
	bool success;

	[Parameter]
	public ApplicantProfileRequest ApplicantProfile { get; set; }


	[Inject]
	private IClientApplicantService ClientApplicantService { get; set; }

	[Inject]
	private NavigationManager NavigationManager { get; set; }

	protected override async Task OnInitializedAsync()
	{
		if (ApplicantProfile != null)
		{
			model = ApplicantProfile;

			if (!string.IsNullOrEmpty(ApplicantProfile.WorkExperiences))
			{
				WorkExperiences = JsonConvert.DeserializeObject<List<WorkExperience>>(ApplicantProfile.WorkExperiences);
			}
		}

	}


	protected void AddWorkExperience()
	{
		WorkExperiences.Add(new());
	}
	protected void DeleteWorkExperience(int index)
	{
		WorkExperiences.RemoveAt(index);
	}

	protected async Task OnValidSubmit(EditContext context)
	{
		success = true;

		if (WorkExperiences.Count() > 0)
		{
			model.WorkExperiences = JsonConvert.SerializeObject(WorkExperiences);
		}

		await ClientApplicantService.UpdateProfile(model);
		NavigationManager.NavigateTo("/applicant-information/0");

	}
}
