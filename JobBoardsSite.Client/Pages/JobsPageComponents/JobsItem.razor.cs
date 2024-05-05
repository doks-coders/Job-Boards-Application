using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Responses;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages.JobsPageComponents
{
    public partial class JobsItem
    {
        [Parameter]
        public JobListItemResponse Job { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        List<string> SelectedSkills = new();
        List<string> WorkLocationType = new();

        protected override async Task OnInitializedAsync()
        {
            
            SelectedSkills = ConvertStringToList(Job.SelectedSkills);
            WorkLocationType = ConvertStringToList(Job.WorkLocationType);
        }


        protected void GoToLink()
        {
            NavigationManager.NavigateTo("/job-information/"+Job.Id);

		}
        private List<string> ConvertStringToList(string item)
        {
            string[] values = item.Split("||", StringSplitOptions.RemoveEmptyEntries);
            return values.ToList();
        }

    }
}
