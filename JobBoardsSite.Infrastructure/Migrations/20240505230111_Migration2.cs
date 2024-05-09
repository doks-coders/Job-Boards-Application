using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoardsSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicantJobApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    DateApplied = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecruiterId = table.Column<int>(type: "int", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicantJobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicantJobApplications_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ApplicantJobApplications_AspNetUsers_RecruiterId",
                        column: x => x.RecruiterId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobApplications_ApplicantId",
                table: "ApplicantJobApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobApplications_RecruiterId",
                table: "ApplicantJobApplications",
                column: "RecruiterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicantJobApplications");
        }
    }
}
