using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Helpers
{
	[Mapper]
	public partial class MapperProfiles
	{
		public partial JobItem JobRequestToJob(CreateJobRequest request);

		public partial List<JobListItemResponse> JobsToJobListItemResponse(List<JobItem> jobs);

		public partial JobItemResponse JobToJobItemResponse(JobItem job);

		public partial ApplicationUser RecruiterProfileRequestToUser(RecruiterProfileRequest request);

		public partial ApplicationUser ApplicantProfileRequestToUser(ApplicantProfileRequest request);

		public partial ApplicationUser UserToUser(ApplicationUser user);



	}
}
