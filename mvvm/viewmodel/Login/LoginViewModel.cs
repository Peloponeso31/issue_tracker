using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects.errorObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.windows;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.Login
{
    public class LoginViewModel : ObservableObject
    {
        private string _usuario;
        public string Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return  _password;
            }
            set
            {
                 _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private Visibility _visibilidadMensajeError;
        public Visibility VisibilidadMensajeError
        {
            get
            {
                return _visibilidadMensajeError;
            }
            set
            {
                _visibilidadMensajeError = value;
                OnPropertyChanged(nameof(VisibilidadMensajeError));
            }
        }

        private string _mensajeError;
        public string MensajeError
        {
            get
            {
                return _mensajeError;
            }
            set
            {
                _mensajeError = value;
                OnPropertyChanged(nameof(MensajeError));
            }
        }

        public RelayCommand Registrarse { get; set; }
        public RelayCommand IniciarSesionCommand { get; set; }

        private readonly LoginWindowViewModel _loginWindowViewModel;

        public LoginViewModel(LoginWindowViewModel loginWindowViewModel)
        {
            _loginWindowViewModel = loginWindowViewModel;
            VisibilidadMensajeError = Visibility.Hidden;

            IniciarSesionCommand = new RelayCommand(o =>
            {
                IniciarSesion();
            });

            Registrarse = new RelayCommand(o =>
            {
                _loginWindowViewModel.CurrentViewModel = new RegistrarUsuarioViewModel(_loginWindowViewModel);
            });
        }

        private async void IniciarSesion()
        {
            VisibilidadMensajeError = Visibility.Hidden;
            var resultado = await HttpClientHandler.GetTokenRequest(Usuario, Password);
            
            if (resultado.GetType() == typeof(Token))
            {
                var dashboard = new Dashboard();
                dashboard.Show();

                Window parent = Application.Current.MainWindow;
                parent.Close();
            }

            if (resultado.GetType() == typeof(Error))
            {
                Error error = (Error) resultado;
                MensajeError = error.error;
                VisibilidadMensajeError = Visibility.Visible;
            }

            if (resultado.GetType() == typeof(ErrorValidacion))
            {
                ErrorValidacion error = (ErrorValidacion)resultado;
                MensajeError = error.error;
                VisibilidadMensajeError = Visibility.Visible;
            }
        }
    }
}
