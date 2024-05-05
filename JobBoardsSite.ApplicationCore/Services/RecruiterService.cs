using JobBoardsSite.ApplicationCore.Helpers;
using JobBoardsSite.ApplicationCore.Services.Interfaces;
using JobBoardsSite.Infrastructure.Repositories.Interfaces;
using JobBoardsSite.Shared.Entities;
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
	}
}
