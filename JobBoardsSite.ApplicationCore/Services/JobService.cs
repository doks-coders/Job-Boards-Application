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
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
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
			if (!await _unitOfwork.SaveChanges()) throw new CustomException(ErrorCodes.ChangesNotSaved);
			return new ResponseModal()
			{
				Message = "Created Successfully",
				isSuccess = true
			};

		}

		public async Task<ResponseModal> EditJob(EditJobRequest jobRequest)
		{
			var job = await _unitOfwork.Jobs.GetOne(u => u.Id == jobRequest.Id);
			job.Salary = jobRequest.Salary;
			job.SelectedSkills = jobRequest.SelectedSkills;
			job.About = jobRequest.About;
			job.JobFunction = jobRequest.JobFunction;
			job.JobTitle = jobRequest.JobTitle;
			job.Qualifications = jobRequest.Qualifications;
			job.Responsiblities = jobRequest.Responsiblities;
			job.WorkLocationType = jobRequest.WorkLocationType;
			job.WorkType = jobRequest.WorkType;
	
			if (!await _unitOfwork.SaveChanges()) throw new CustomException(ErrorCodes.ChangesNotSaved);
			return new ResponseModal()
			{
				Message = "Updated Successfully",
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


		public async Task<ResponseModal> GetJob(int id,ClaimsPrincipal user)
		{
			int userid = 0;
			bool isAuthUser = false;
			try
			{
                userid = user.GetUserId();
			}
			catch (Exception)
			{

			}

			
			var job = await _unitOfwork.Jobs.GetOne(u => u.Id == id,includeProperties:"Recruiter");
			
			if (job.RecruiterId == userid)
			{
				isAuthUser = true;

            }
           
            var jobsResponses = _mapper.JobToJobItemResponse(job);
			jobsResponses.isAuthUser = isAuthUser;
			jobsResponses.CompanyId = job.RecruiterId;
			jobsResponses.CompanyName = job.Recruiter.Name;
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
