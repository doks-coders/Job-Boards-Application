using JobBoardsSite.Shared.Models;

namespace JobBoardsSite.Client.Pages
{
	public partial class Index
	{
		bool _drawerOpen = true;

		void DrawerToggle()
		{
			_drawerOpen = !_drawerOpen;

			
		}
	}
}
