﻿using JobBoardsSite.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobBoardsSite.Infrastructure.Configurations;

public class AppRoleConfigurations : IEntityTypeConfiguration<AppRole>
{
	public void Configure(EntityTypeBuilder<AppRole> builder)
	{
		builder.HasMany(u => u.UserRoles)
			.WithOne(u => u.AppRole)
			.HasForeignKey(u => u.RoleId)
			.IsRequired()
			.OnDelete(DeleteBehavior.NoAction);

	}
}
