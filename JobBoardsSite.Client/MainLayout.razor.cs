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
    }
}
