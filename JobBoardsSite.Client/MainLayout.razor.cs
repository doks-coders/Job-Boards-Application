using JobBoardsSite.Client.Services;
using JobBoardsSite.Client.Services.Interfaces;
using JobBoardsSite.Shared.Constants;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using MudBlazor;

namespace JobBoardsSite.Client
{
    public partial class MainLayout
    {
        public MudTheme Theme = new MudTheme()
        {
            Typography = new Typography()
            {
                Default = new Default()
                {
                    FontFamily = new string[] { "Poppins", "Helvetica", "Arial", "sans-serif" }
                }
            }
        };

        private string currentLocation { get; set; }

        [Inject]
        AuthenticationStateProvider _authenticationStateProvider { get; set; }

        [Inject]
        public IClientAuthService ClientAuthService { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var res = await _authenticationStateProvider.GetAuthenticationStateAsync();
            ClientAuthService.RaiseEventAuthenticationStateChanged(res);

            NavigationManager.LocationChanged += HandleLocationChanged;


            if (ClientAuthService.AuthenticationState.User.IsInRole(RoleConstants.Recruiter))
            {
                NavigationManager.NavigateTo("/recruiter-admin-homepage");
            }
        

		}


		public void GoToHomePage()
		{
			NavigationManager.NavigateTo("/");
		}
		public void GoToLink()
		{
			NavigationManager.NavigateTo("/applicant-information/0");
		}
		public async Task Logout()
		{
            var res = await ClientAuthService.SignOutUser();
            ClientAuthService.RaiseEventAuthenticationStateChanged(res);

            NavigationManager.NavigateTo("/login");
		}

		private List<string> ApplicantsUrl = new() {
            "/create-applicant-info",
            "/edit-applicant-info"
        };

        private List<string> RecruitersUrl = new() { 
            "job-create",
            "job-edit",
            "view-your-applicants",
            "view-your-jobs",
            "edit-recruiter-information",
            "create-recruiter-information",
            "recruiter-admin-homepage",
            "view-prospective-applicants"
        };

        private async void HandleLocationChanged(object sender, LocationChangedEventArgs e)
        {
            if (currentLocation != e.Location)
            {
                var isApplicant = ClientAuthService.AuthenticationState.User.IsInRole(RoleConstants.Applicant);
                var isRecruiter = ClientAuthService.AuthenticationState.User.IsInRole(RoleConstants.Recruiter);

                if (ApplicantsUrl.Any(u => (e.Location.Contains(UrlConstants.BaseFrontendURL + u))))
                {
                    if (!isApplicant)
                    {
                        NavigationManager.NavigateTo("/login");
                    }
                }

                if (RecruitersUrl.Any(u => (e.Location.Contains(UrlConstants.BaseFrontendURL + u))))
                {
                    if (!isRecruiter)
                    {
                        NavigationManager.NavigateTo("/login");
                    }
                }
            }
            currentLocation = e.Location;

        }

        public void Dispose()
        {
            // Remember to unsubscribe from the event to avoid memory leaks
            NavigationManager.LocationChanged -= HandleLocationChanged;
        }
    }
}
