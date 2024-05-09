using JobBoardsSite.ApplicationCore.Helpers;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.ApplicationCore.Services
{
	public class JobService : IJobService
	{
		private readonly IUnitOfWork _unitOfwork;
		private readonly MapperProfiles _mapper;
		public JobService(IUnitOfWork unitOfwork)
		{
			_unitOfwork = unitOfwork;
			_mapper = new MapperProfiles();
		}



		public async Task<ResponseModal> CreateJob(CreateJobRequest jobRequest, int userId)
		{
			var job = _mapper.JobRequestToJob(jobRequest);
			job.RecruiterId = userId;
			await _unitOfwork.Jobs.AddItem(job);
			if (!await _unitOfwork.SaveChanges()) throw new CustomException(ErrorCodes.DatabaseError);
			return new ResponseModal()
			{
				Message = "Created Successfully",
				isSuccess = true
			};

		}



		public async Task<ResponseModal> GetJobs()
		{
			var jobs = await _unitOfwork.Jobs.GetAll(u => u.Id != null);

			var jobsResponses = _mapper.JobsToJobListItemResponse(jobs.ToList());
			return new ResponseModal()
			{
				Data = jobsResponses,
				Message = "Retrieved Successfully",
				isSuccess = true
			};
		}


		public async Task<ResponseModal> GetJob(int id)
		{
			var job = await _unitOfwork.Jobs.GetOne(u => u.Id == id);

			var jobsResponses = _mapper.JobToJobItemResponse(job);
			return new ResponseModal()
			{
				Data = jobsResponses,
				Message = "Retrieved Successfully",
				isSuccess = true
			};
		}

		private Expression<Func<JobItem, bool>> Search(PaginationRequest request)
		{
			return u =>
			(string.IsNullOrEmpty(request.Country) || request.Country == "All" || u.Recruiter.Country == request.Country)
			&&
			(string.IsNullOrEmpty(request.WorkType) || request.WorkType == "All" || u.WorkType.Contains(request.WorkType))
			&& 
			(string.IsNullOrEmpty(request.Skills) || request.Skills == "All" || u.SelectedSkills.Contains(request.Skills));
		}


		public async Task<ResponseModal> GetJobPagination(PaginationRequest request)
		{
			var response = await _unitOfwork.Jobs.GetPagination(request, Search(request), includeProperties: "Recruiter");

			var jobitems = response.Items as List<JobItem>;
			var jobsResponses = jobitems.Select(e => new JobListItemResponse()
			{
				CompanyName = e.Recruiter.Name,
				Id = e.Id,
				JobTitle = e.JobTitle,
				Salary = e.Salary,
				SelectedSkills = e.SelectedSkills,
				WorkLocationType = e.WorkLocationType,

			}).ToList();
			//var jobsResponses = _mapper.JobsToJobListItemResponse(jobitems);
			response.Items = jobsResponses;


			return new ResponseModal()
			{
				Data = response,
				isSuccess = true
			};
		}
	}
}
