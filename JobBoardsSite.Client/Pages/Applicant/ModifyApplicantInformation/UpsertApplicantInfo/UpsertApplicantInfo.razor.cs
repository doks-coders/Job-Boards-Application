using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Client.Pages.Applicant.ModifyApplicantInformation.UpsertApplicantInfo
{
	public partial class UpsertApplicantInfo
	{

		ApplicantProfileRequest model = new ApplicantProfileRequest();
		bool success;


		[Inject]
		private IClientApplicantService ClientApplicantService { get; set; }
		

	

		protected void AddWorkExperience()
		{
			model.WorkExperiences.Add(new());
		}

		protected async Task OnValidSubmit(EditContext context)
		{
			success = true;

			await ClientApplicantService.UpdateProfile(model);

		}
	}
}
