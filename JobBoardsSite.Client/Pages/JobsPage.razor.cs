using JobBoardsSite.Client.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace JobBoardsSite.Client.Pages
{
	public partial class JobsPage
	{
		[Inject]
		public IClientAuthService ClientAuthService { get; set; }


	}
}
