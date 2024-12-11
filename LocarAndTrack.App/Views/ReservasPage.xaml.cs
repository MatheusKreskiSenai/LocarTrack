using LocarAndTrack.App.ViewModels;

namespace LocarAndTrack.App.Views;

public partial class ReservasPage : ContentPage
{
	ReservasViewModel viewModel;
	public ReservasPage()
	{
		InitializeComponent();
		viewModel = new ReservasViewModel();
		BindingContext = viewModel;
	}
}