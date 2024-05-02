using JobBoardsSite.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobBoardsSite.Infrastructure.Configurations
{
	public class AppUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.HasMany(u => u.UserRoles)
				.WithOne(u => u.AppUser)
				.HasForeignKey(u => u.UserId)
				.IsRequired()
				.OnDelete(DeleteBehavior.NoAction);


		}
	}
}
