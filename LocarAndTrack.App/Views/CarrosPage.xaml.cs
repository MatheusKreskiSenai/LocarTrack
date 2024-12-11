using LocarAndTrack.App.ViewModels;

namespace LocarAndTrack.App.Views;

public partial class CarrosPage : ContentPage
{
	CarrosViewModel viewModel;
	public CarrosPage()
	{
		InitializeComponent();
		viewModel = new CarrosViewModel();
		BindingContext = viewModel;
	}
}