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
using System.Windows.Shapes;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.windows
{
    /// <summary>
    /// Interaction logic for VisualizadorPDF.xaml
    /// </summary>
    public partial class VisualizadorPDF : Window
    {
        public VisualizadorPDF()
        {
            InitializeComponent();
            webView.Source = new Uri("https://www.orimi.com/pdf-test.pdf");
        }
    }
}
