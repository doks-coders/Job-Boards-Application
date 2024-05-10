using JobBoardsSite.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Shared.Models
{
	public class ErrorResponseModal
	{
		public string StackTrace { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public string StatusCode { get; set; } = string.Empty;

		public ErrorResponseModal(string errorCode, string message, string stackTrace)
		{
			try
			{
				if (Enum.TryParse(errorCode, out ErrorCodes result))
				{
					var errorFound = ErrorDictionary[result];

					Message = errorFound["Message"];
					StatusCode = errorFound["Code"];
					StackTrace = stackTrace;
				}
				else
				{
					Message = message;
					StatusCode = Convert.ToString((int)HttpStatusCode.InternalServerError);
					StackTrace = stackTrace;
				}


			}
			catch (Exception)
			{
				Message = message;
				StatusCode = Convert.ToString((int)HttpStatusCode.InternalServerError);
				StackTrace = stackTrace;
			}

		}



		public static Dictionary<ErrorCodes, Dictionary<string, string>> ErrorDictionary =>
			new()
			{
				
				//Authentication
				{
					ErrorCodes.NotAuthorised,new (){

						{ "Code", Convert.ToString((int) HttpStatusCode.Forbidden)},
						{ "Message", "You are not allowed" }
					}
				},

				{
					ErrorCodes.WrongPassword,new (){

						{ "Code", Convert.ToString((int) HttpStatusCode.Forbidden) },
						{ "Message", "Wrong Password" }
					}
				},

				{
					ErrorCodes.EmailDoesntExist,new (){

						{ "Code", Convert.ToString((int) HttpStatusCode.NotFound) },
						{ "Message", "Email does not exist" }
					}
				},

				{
					ErrorCodes.PasswordsMismatch,new (){

						{ "Code", Convert.ToString((int) HttpStatusCode.Forbidden) },
						{ "Message", "Passwords do not match" }
					}
				},
				{
					ErrorCodes.UserExists,new (){

						{ "Code",  Convert.ToString((int) HttpStatusCode.Unauthorized)},
						{ "Message", "User Exists Already" }
					}
				},


				

				//System Error
				


				{
					ErrorCodes.ChangesNotSaved,new (){

						{ "Code",  Convert.ToString((int) HttpStatusCode.InternalServerError)},
						{ "Message", "Changes did not save" }
					}
				},

				{
					ErrorCodes.InternalServerError,new (){

						{ "Code",  Convert.ToString((int) HttpStatusCode.InternalServerError)},
						{ "Message", "You have an internal server error" }
					}
				},

				{
					ErrorCodes.DatabaseError,new (){

						{ "Code", Convert.ToString((int) HttpStatusCode.InternalServerError) },
						{ "Message", "Database Error" }
					}
				},
				{
					ErrorCodes.UserDoesntExist,new (){

						{ "Code", Convert.ToString((int) HttpStatusCode.NotFound) },
						{ "Message", "User does not exist" }
					}
				},
			};


	}
}
