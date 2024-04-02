using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.Login
{
    public class RegistrarUsuarioViewModel : ObservableObject
    {
        private readonly LoginWindowViewModel _loginWindowViewModel;
        public RelayCommand RegresarIniciarSesion { get; set; }

        public RegistrarUsuarioViewModel(LoginWindowViewModel loginWindowViewModel)
        {
            _loginWindowViewModel = loginWindowViewModel;

            RegresarIniciarSesion = new RelayCommand(o =>
            {
                _loginWindowViewModel.CurrentViewModel = new LoginViewModel(_loginWindowViewModel);
            });

        }
    }
}
