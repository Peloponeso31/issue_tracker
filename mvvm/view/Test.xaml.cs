using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.windows;
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

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : UserControl
    {
        public Test()
        {
            InitializeComponent();
        }

        private async void BotonPrueba_Click(object sender, RoutedEventArgs e)
        {
            string ruta = await core.HttpClientHandler.GetReportePdf();
            
            var viewer = new VisualizadorPDF(ruta);
            viewer.Show();
        }
    }
}
