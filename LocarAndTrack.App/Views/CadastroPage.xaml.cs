using LocarAndTrack.App.ViewModels;

namespace LocarAndTrack.App.Views;

public partial class CadastroPage : ContentPage
{
	CadastroViewModel _viewModel;
	public CadastroPage()
	{
		InitializeComponent();
		_viewModel = new CadastroViewModel();
		BindingContext = _viewModel;
	}
}