using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects.errorObjects;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.windows
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void autenticar_click(object sender, RoutedEventArgs e)
        {
            string email_str = email.Text.ToString();
            string password_str = password.Password.ToString();

            var resultado = await core.HttpClientHandler.GetTokenRequest(email_str, password_str);

            if (resultado.GetType() == typeof(User))
            {
                var dashboard = new Dashboard((User)resultado);
                dashboard.Show();
                this.Close();
            }
            else if (resultado.GetType() == typeof(errorValidacion))
            {
                errorValidacion error = (errorValidacion)resultado;
                this.MensajeDeError.Text = error.error;
                this.MensajeDeError.Visibility = Visibility.Visible;
            }
        }

    }
}
