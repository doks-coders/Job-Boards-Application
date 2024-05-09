using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Riok.Mapperly.Abstractions;

namespace JobBoardsSite.Client.Helpers
{
	[Mapper]
	public partial class ClientMapperProfiles
	{
		public partial ApplicantProfileRequest ApplicantResponseToApplicantProfileRequest(ApplicantResponse response);
		public partial RecruiterProfileRequest RecruiterResponseToRecruitertProfileRequest(RecruiterResponse response);

	}
}
