using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view.FormularioReportes.Pestanas
{
    public partial class PestanaSenasParticularesView : UserControl
    {
        public PestanaSenasParticularesView()
        {
            InitializeComponent();

            comboBox1.Text = "Tipo";
            comboBox2.Text = "Lado";
            comboBox3.Text = "Vista";
            comboBox4.Text = "Cantidad";
        }
    }
}
