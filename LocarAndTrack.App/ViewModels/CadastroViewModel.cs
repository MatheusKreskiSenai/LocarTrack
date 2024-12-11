using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocarAndTrack.App.ViewModels
{
    public partial class CadastroViewModel : ObservableObject
    {
        public CadastroViewModel() { }

        [ObservableProperty]
        private string _nome;

        [ObservableProperty]
        private string _email;

        [ObservableProperty]
        private int _cpf;

        [ObservableProperty]
        private string _password;

        [RelayCommand]
        private async Task Logar()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private async Task Entrar()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}
