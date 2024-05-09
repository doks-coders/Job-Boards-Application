using JobBoardsSite.Client.Pages.Applicant.JobInformation;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JobBoardsSite.Client.Pages.Applicant.JobInformation
{

	public partial class JobInformation
	{
        [Parameter]
        public int Id { get; set; }


        [Inject]
		IDialogService DialogService { get; set; }


        [Inject]
        IClientJobService JobService { get; set; }


		[Inject]
		IClientApplicantService ApplicantService { get; set; }

		public JobItemResponse? Job { get; set; }


		protected override async Task OnInitializedAsync()
		{

			Job = await JobService.GetJob(Id);
				
				/*new JobItemResponse()
			{
				JobTitle = "Project Manager",


				About = "We are a dynamic company seeking an experienced Project Manager to lead our team in delivering successful projects. As a Project Manager, you will play a crucial role in planning, executing, and closing projects on time and within budget. Join us and be part of an exciting journey in driving innovation and excellence.",


				Salary = "90,000",


				Responsiblities = "Lead project planning, scheduling, budgeting, and resource allocation.|| Coordinate project team activities and ensure adherence to project timelines and deliverables||Communicate project status, risks, and issues to stakeholders and senior management.",


				Qualifications = "Bachelor's degree in Business Administration, Project Management, or related field.||Proven experience managing complex projects in a fast-paced environment.||Strong leadership and communication skills with the ability to influence and motivate teams.",


				SelectedSkills = "Project Management||Leadership||Communication||Risk Management",


				JobFunction = "Information Technology",


				WorkLocationType = "Remote||On-Site",


				WorkType = "Full Time||Part Time",


				ContactEmail = "guonnie@gmail.com"
			};
				*/
		}


		protected async Task ApplyToJob()
		{
			var res = await ApplicantService.JobApply(Job.Id);
			var parameters = new DialogParameters<JobAppliedDialog>();
			parameters.Add(x => x.ContentText, res.Message);

			var options = new DialogOptions { CloseOnEscapeKey = true, };
			DialogService.Show<JobAppliedDialog>("Job Application", parameters);
		}
	}
}
