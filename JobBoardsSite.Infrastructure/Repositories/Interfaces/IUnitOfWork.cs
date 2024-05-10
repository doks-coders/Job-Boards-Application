namespace JobBoardsSite.Infrastructure.Repositories.Interfaces;

public interface IUnitOfWork
{
	IJobRepository Jobs { get; }
	IAppUserRepository Users { get; }
	IApplicantJobApplicationRepository ApplicantJobApplications { get; }
	Task<bool> SaveChanges();
}
