using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Requests;
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
		public partial JobItem JobRequestToJob(CreateJobRequest message);

	}
}
