using JobBoardsSite.ApplicationCore.Helpers;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Constants;
using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;
using System.Linq.Expressions;

namespace JobBoardsSite.ApplicationCore.Services;

public class ApplicantService : IApplicantService
{
	private readonly IUnitOfWork _unitOfWork;

	private readonly MapperProfiles _mapper;
	public ApplicantService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
		_mapper = new();
	}

	public async Task<ResponseModal> JobApply(int userId, int jobId)
	{
		if (await _unitOfWork.ApplicantJobApplications.GetOne(u => u.ApplicantId == userId && u.JobId == jobId) != null) return new ResponseModal() { isSuccess = true, Message = "You have already applied to this job" };
		var job = await _unitOfWork.Jobs.GetOne(u => u.Id == jobId, includeProperties: "Recruiter");
		if (job == null) throw new CustomException(ErrorCodes.UserDoesntExist);

		await _unitOfWork.ApplicantJobApplications.AddItem(new ApplicantJobApplication()
		{
			ApplicantId = userId,
			RecruiterId = job.RecruiterId,
			JobId = job.Id
		});

		if (await _unitOfWork.SaveChanges())
		{
			return new ResponseModal() { isSuccess = true, Message = "Applied Successfully" };
		}
		throw new CustomException(ErrorCodes.DatabaseError);
	}

	public async Task<ResponseModal> GetApplicantDetails(int userId, int paramUserId)
	{
		var isUser = false;
		if (userId == paramUserId)
		{
			isUser = true;
		}

		var responseUser = await GetApplicant(paramUserId);
		responseUser.isAuthUser = isUser;

		return new ResponseModal()
		{
			Data = responseUser,
			Message = "Completed Successfully"
		};


	}

	public async Task<ResponseModal> GetApplicantDetails(int userId)
	{
		var responseUser = await GetApplicant(userId);
		responseUser.isAuthUser = true;

		return new ResponseModal()
		{
			Data = responseUser,
			Message = "Completed Successfully"
		};


	}


	private async Task<ApplicantResponse> GetApplicant(int id)
	{
		var user = await _unitOfWork.Users.GetOne(u => u.Id == id);
		if (user == null) throw new CustomException(ErrorCodes.UserDoesntExist);
		var responseUser = _mapper.ApplicationUserToApplicantResponse(user);
		return responseUser;
	}

	public async Task<ResponseModal> UpdateApplicantInfo(int userId, ApplicantProfileRequest request)
	{
		var user = await _unitOfWork.Users.GetOne(u => u.Id == userId);
		user.Name = request.Name;
		user.AverageSalary = request.AverageSalary;
		user.PhoneNumber = request.PhoneNumber;
		user.City = request.City;
		user.Country = request.Country;
		user.SelectedSkills = request.SelectedSkills;
		user.ShortBio = request.ShortBio;
		user.Title = request.Title;
		if (request.WorkExperiences != null)
		{
			user.WorkExperiences = request.WorkExperiences;
		}

		user.ProfileCompleted = true;

		if (await _unitOfWork.SaveChanges())
		{
			return new ResponseModal() { isSuccess = true, Message = "Applicant Created Successfully" };
		}
		throw new CustomException(ErrorCodes.DatabaseError);
	}


	private Expression<Func<ApplicationUser, bool>> Search(PaginationRequest request)
	{
		return u => u.UserType == RoleConstants.Applicant
		  && (string.IsNullOrEmpty(request.Country) || request.Country == "All" || u.Country == request.Country)
		  && (string.IsNullOrEmpty(request.Skills) || request.Skills == "All" || u.SelectedSkills.Contains(request.Skills));
	}

	public async Task<ResponseModal> SearchApplicants(PaginationRequest request)
	{
		string[] skills = request.Skills.Split("||");

		Expression<Func<ApplicationUser, bool>> filterPredicate = u => u.SelectedSkills.Contains(request.Skills);


		var response = await _unitOfWork.Users.GetPagination(request, Search(request));

		var Items = response.Items as List<ApplicationUser>;
		var applicantResponse = _mapper.ApplicationUserToApplicantItemResponse(Items);
		response.Items = applicantResponse;

		return new ResponseModal() { Data = response, Message = "Retrieved Successfully" };
	}
}



/*
 private bool CheckValue(ApplicationUser user, PaginationRequest request)
	{
		if (!string.IsNullOrEmpty(request.Skills) && !string.IsNullOrEmpty(request.Country))
		{
			string[] skills = request.Skills.Split("||");
			if (skills.All(e => user.SelectedSkills.Contains(e)
			&&
			user.UserType == RoleConstants.Applicant.ToString()
			&&
			user.Country == request.Country
			))return true;

			return false;			
		}
		

		if (!string.IsNullOrEmpty(request.Skills))
		{
			string[] skills = request.Skills.Split("||");

			if (skills.All(e => user.SelectedSkills.Contains(e)
			&&
			user.UserType == RoleConstants.Applicant.ToString()
			)) return true;
			return false;
		}
		if (!string.IsNullOrEmpty(request.Country))
		{
			if (user.Country == request.Country
			&&
			user.UserType == RoleConstants.Applicant.ToString()
			) return true;

			return false;
		}

		if (user.UserType == RoleConstants.Applicant.ToString()
		) return true;

		return false;
	}
 */