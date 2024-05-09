using JobBoardsSite.Client.Helpers;
using JobBoardsSite.Client.Services;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
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

		[Inject]
		public NavigationManager NavigationManager { get; set; }

		[Parameter]
		public RecruiterResponse Recruiter { get; set; }	

		RecruiterProfileRequest model = new RecruiterProfileRequest();

		protected override async Task OnInitializedAsync()
		{
			if (Recruiter != null)
			{
				var _mapper = new ClientMapperProfiles();
				model = _mapper.RecruiterResponseToRecruitertProfileRequest(Recruiter);
			}
		}

		protected async Task OnValidSubmit(EditContext context)
		{
			success = true;
			await ClientRecruiterService.UpdateProfile(model);

			NavigationManager.NavigateTo("/recruiter-admin-homepage");

		}

	}
}
