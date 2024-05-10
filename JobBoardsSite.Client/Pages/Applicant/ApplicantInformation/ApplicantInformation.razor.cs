using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace JobBoardsSite.Client.Pages.Applicant.ApplicantInformation;

public partial class ApplicantInformation
{
	[Parameter]
	public int Id { get; set; }

	public ApplicantResponse Applicant = null;

	public List<WorkExperience> WorkExperiences = null;



	[Inject]
	IClientApplicantService ClientApplicantService { get; set; }

	protected override async Task OnInitializedAsync()
	{
		if (Id == null || Id == 0)
		{
			Applicant = await ClientApplicantService.GetApplicantMyInfo();
		}
		else
		{
			Applicant = await ClientApplicantService.GetApplicantInfo(Id);
		}

		if (!string.IsNullOrEmpty(Applicant.WorkExperiences))
		{
			WorkExperiences = JsonConvert.DeserializeObject<List<WorkExperience>>(Applicant.WorkExperiences);

		}




		//answersPoints.All(point => savedPoints.Contains(point));

	}
}
