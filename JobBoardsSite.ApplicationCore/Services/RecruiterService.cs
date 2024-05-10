using JobBoardsSite.ApplicationCore.Helpers;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Entities;
using JobBoardsSite.Shared.Enums;
using JobBoardsSite.Shared.Models;
using JobBoardsSite.Shared.Requests;
using JobBoardsSite.Shared.Responses;

namespace JobBoardsSite.ApplicationCore.Services;


public class RecruiterService : IRecruiterService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly MapperProfiles _mapper;
	public RecruiterService(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
		_mapper = new();
	}
	public async Task<ResponseModal> UpdateRecruiter(int userId, RecruiterProfileRequest request)
	{
		var user = await _unitOfWork.Users.GetOne(u => u.Id == userId);

		user.Name = request.Name;
		user.About = request.About;
		user.PhoneNumber = request.PhoneNumber;
		user.City = request.City;
		user.Country = request.Country;
		user.Industry = request.Industry;
		user.ProfileCompleted = true;

		if (await _unitOfWork.SaveChanges())
		{
			return new ResponseModal() { isSuccess = true, Message = "Recruiter Created Successfully" };
		}
		throw new CustomException(ErrorCodes.DatabaseError);
	}
	//Applicant,Job

	public async Task<ResponseModal> GetMyApplicants(int userId)
	{

		var applications = await _unitOfWork.ApplicantJobApplications.GetAll(u => u.RecruiterId == userId, includeProperties: "Applicant,Job");

		applications = applications.OrderByDescending(u => u.DateApplied);

		var applicantTable = applications.Select(e => new ApplicantsTableResponse()
		{
			Id = e.ApplicantId,
			Name = e.Applicant.Name,
			Email = e.Applicant.Email,
			JobTitle = e.Job.JobTitle,
			Salary = e.Applicant.AverageSalary
		}).ToList();



		return new ResponseModal() { Data = applicantTable, isSuccess = true };

	}

	public async Task<ResponseModal> GetMyJobs(int userId)
	{

		var applications = await _unitOfWork.Jobs.GetAll(u => u.RecruiterId == userId);

		applications = applications.OrderByDescending(u => u.Created);

		var applicantTable = applications.Select(e => new JobItemTableResponse()
		{
			JobId = e.Id,
			ContactEmail = e.ContactEmail,
			JobTitle = e.JobTitle,
			Salary = e.Salary
		}).ToList();


		return new ResponseModal() { Data = applicantTable, isSuccess = true };

	}

	public async Task<ResponseModal> GetRecruiterInfo(int userId, int paramUserId)
	{
		bool isAuthUser = false;
		var _ = (userId == paramUserId) ? isAuthUser = true : isAuthUser = false;

		var recruiter = await GetRecruiter(userId);
		var response = _mapper.ApplicationUserToRecruiterResponse(recruiter);
		response.isAuthUser = isAuthUser;
		return new ResponseModal() { Data = response, Message = "Returned Successfully" };
	}



	public async Task<ResponseModal> GetMyRecruiterInfo(int userId)
	{
		var recruiter = await GetRecruiter(userId);
		var response = _mapper.ApplicationUserToRecruiterResponse(recruiter);
		response.isAuthUser = true;
		return new ResponseModal() { Data = response, Message = "Returned Successfully" };
	}

	private async Task<ApplicationUser> GetRecruiter(int id)
	{
		var recruiter = await _unitOfWork.Users.GetOne(u => u.Id == id);
		if (recruiter == null) throw new CustomException(ErrorCodes.UserDoesntExist);

		return recruiter;
	}

}
