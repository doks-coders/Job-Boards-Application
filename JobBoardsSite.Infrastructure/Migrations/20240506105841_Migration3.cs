using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoardsSite.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ApplicantJobApplications_JobId",
                table: "ApplicantJobApplications",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicantJobApplications_JobItems_JobId",
                table: "ApplicantJobApplications",
                column: "JobId",
                principalTable: "JobItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicantJobApplications_JobItems_JobId",
                table: "ApplicantJobApplications");

            migrationBuilder.DropIndex(
                name: "IX_ApplicantJobApplications_JobId",
                table: "ApplicantJobApplications");
        }
    }
}
