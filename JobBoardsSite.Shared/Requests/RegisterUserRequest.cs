namespace JobBoardsSite.Shared.Requests;

public record RegisterUserRequest(string Email, string UserType, string Password, string Verify);
