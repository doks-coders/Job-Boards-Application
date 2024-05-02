using JobBoardsSite.ApplicationCore.Helpers;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services
{
	public class JobService:IJobService
	{
		private readonly IUnitOfWork _unitOfwork;
		private readonly MapperProfiles _mapper;
		public JobService(IUnitOfWork unitOfwork)
		{
			_unitOfwork = unitOfwork;
			_mapper = new MapperProfiles();
		}

		

		public async Task<ResponseModal> CreateJob(CreateJobRequest jobRequest)
		{
			var job = _mapper.JobRequestToJob(jobRequest);
			await _unitOfwork.Jobs.AddItem(job);
			if (!await _unitOfwork.SaveChanges()) throw new CustomException(ErrorCodes.DatabaseError);
			return new ResponseModal()
			{
				Message = "Created Successfully",
				isSuccess = true
			};
			
		}
	}
}
