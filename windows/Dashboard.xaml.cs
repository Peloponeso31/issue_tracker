using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private User UsuarioAutenticado;
        public Dashboard(User usuario)
        {
            InitializeComponent();
            this.UsuarioAutenticado = usuario;

            this.NombreUsuario.Text = this.UsuarioAutenticado.name;
        }
    }
}
