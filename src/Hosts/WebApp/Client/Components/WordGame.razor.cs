using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace WebApp.Client.Components
{
    public partial class WordGame : ComponentBase
    {
        private bool collapseNavMenu = true;

        private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        [Inject] public NavigationManager NavigationManager { get; set; } = null!;

        public WordGame()
        {

        }

        private void BeginLogOut()
        {
            Navigation.NavigateToLogout("/logout");
        }

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}