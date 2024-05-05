using JobBoardsSite.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Data
{
    public class AppIdentityDbContext: IdentityDbContext<ApplicationUser, AppRole, int,
		IdentityUserClaim<int>, AppUserRole, IdentityUserLogin<int>,
		IdentityRoleClaim<int>, IdentityUserToken<int>>
	{
		public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
		{

		}

		public DbSet<ApplicationUser> Users { get; set; }
		public DbSet<AppRole> Roles { get; set; }
		public DbSet<AppUserRole> UserRoles { get; set; }

		public DbSet<JobItem> JobItems { get; set; }
		public DbSet<RecruiterJob> RecruiterJobs { get; set; }
		public DbSet<ApplicantJobApplication> ApplicantJobApplications { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			builder.Entity<JobItem>()
				.HasMany(u => u.RecruiterJobs)
				.WithOne(u => u.JobItem)
				.HasForeignKey(u => u.JobId)
				.OnDelete(DeleteBehavior.NoAction);


			builder.Entity<ApplicationUser>()
				.HasMany(u => u.RecruiterJobs)
				.WithOne(u => u.Recruiter)
				.HasForeignKey(u => u.RecruiterId)
				.OnDelete(DeleteBehavior.NoAction);

			base.OnModelCreating(builder);	
		}

	}


}
