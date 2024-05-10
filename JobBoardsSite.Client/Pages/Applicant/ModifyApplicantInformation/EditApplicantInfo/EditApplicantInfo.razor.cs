
using JobBoardsSite.Client.Helpers;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Requests;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.Applicant.ModifyApplicantInformation.EditApplicantInfo
{
	public partial class EditApplicantInfo
	{
		ClientMapperProfiles _mapper;
		ApplicantProfileRequest ApplicantProfileRequest = null;
		[Inject]
		IClientApplicantService ClientApplicantService { get; set; }

		protected override async Task OnInitializedAsync()
		{
			_mapper = new ClientMapperProfiles();
			var applicantInfo = await ClientApplicantService.GetApplicantMyInfo();
			ApplicantProfileRequest = _mapper.ApplicantResponseToApplicantProfileRequest(applicantInfo);
		}
	}
}
