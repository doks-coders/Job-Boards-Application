using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Enums
{
	public enum ErrorCodes
	{
		NotAuthorised,
		WrongPassword,
		EmailDoesntExist,
		PasswordsMismatch,
		InternalServerError,
		DatabaseError,
		UserDoesntExist
	}
}
