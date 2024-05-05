using JobBoardsSite.Client.Services;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace JobBoardsSite.Client.Pages.Recruiter.ModifyRecruiterInformation.RecruiterInformationUpsert
{
	public partial class RecruiterInformationUpsert
	{
		[Parameter]
		public string Mode { get; set; }

		bool success=false;

		[Inject]
		public IClientRecruiterService ClientRecruiterService { get; set; }	

		RecruiterProfileRequest model = new RecruiterProfileRequest();

		protected async Task OnValidSubmit(EditContext context)
		{
			success = true;

			await ClientRecruiterService.UpdateProfile(model);

		}

	}
}
