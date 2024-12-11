using LocarAndTrack.App.ViewModels;

namespace LocarAndTrack.App.Views;

public partial class PerfilPage : ContentPage
{
	PerfilViewModel viewModel;
	public PerfilPage()
	{
		InitializeComponent();
		viewModel = new PerfilViewModel();
		BindingContext = viewModel;
	}
}