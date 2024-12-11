using LocarAndTrack.App.ViewModels;

namespace LocarAndTrack.App.Views;

public partial class HomePage : ContentPage
{
	HomePageViewModel viewModel;
	public HomePage()
	{
		InitializeComponent();
		viewModel = new HomePageViewModel();
		BindingContext = viewModel;
	}
}