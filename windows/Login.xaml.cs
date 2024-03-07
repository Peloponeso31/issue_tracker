using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;
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

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view
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
            var dashboard = new Dashboard();
            string email_str = email.Text.ToString();
            string password_str = password.Password.ToString();

            //using HttpResponseMessage response = await model.HttpClientHandler.sharedClient();

            Console.WriteLine();

            dashboard.Show();
            this.Close();
        }

    }
}
