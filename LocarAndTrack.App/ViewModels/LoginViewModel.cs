using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LocarAndTrack.App.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        public LoginViewModel() { }

        [ObservableProperty]
        private int _cpf;

        [ObservableProperty]
        private string _password;

        [RelayCommand]
        public async Task Registrar()
        {
            await Shell.Current.GoToAsync("/CadastroPage");
        }

        [RelayCommand]
        private async Task Entrar()
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}
