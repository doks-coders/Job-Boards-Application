﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoardsSite.Infrastructure.Migrations
{
	/// <inheritdoc />
	public partial class Migration8 : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<string>(
				name: "WorkExperiences",
				table: "AspNetUsers",
				type: "nvarchar(max)",
				nullable: true);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "WorkExperiences",
				table: "AspNetUsers");
		}
	}
}
