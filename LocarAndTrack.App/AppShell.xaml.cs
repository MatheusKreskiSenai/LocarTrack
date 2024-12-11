using LocarAndTrack.App.Views;

namespace LocarAndTrack.App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("CadastroPage", typeof(CadastroPage));
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
        }
    }
}
