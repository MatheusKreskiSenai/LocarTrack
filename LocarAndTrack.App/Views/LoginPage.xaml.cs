using LocarAndTrack.App.ViewModels;

namespace LocarAndTrack.App.Views;

public partial class LoginPage : ContentPage
{
	LoginViewModel viewModel;
	public LoginPage()
	{
		InitializeComponent();
		viewModel = new LoginViewModel();
		BindingContext = viewModel;
	}
}