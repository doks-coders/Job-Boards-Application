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
	public class ApplicantService:IApplicantService
	{
		private readonly IUnitOfWork _unitOfWork;

		public ApplicantService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<ResponseModal> UpdateApplicantInfo(int userId, ApplicantProfileRequest request)
		{
			var user = await _unitOfWork.Users.GetOne(u => u.Id == userId);
			user.AverageSalary = request.AverageSalary;
			user.PhoneNumber = request.PhoneNumber;
			user.City = request.City;
			user.Country = request.Country;
			user.SelectedSkills = request.SelectedSkills;
			user.ShortBio = request.ShortBio;
			user.Title = request.Title;

			user.ProfileCompleted = true;

			if(await _unitOfWork.SaveChanges())
			{
				return new ResponseModal() { isSuccess = true, Message = "Applicant Created Successfully" };
			}
			throw new CustomException(ErrorCodes.DatabaseError);
		}
	}
}
