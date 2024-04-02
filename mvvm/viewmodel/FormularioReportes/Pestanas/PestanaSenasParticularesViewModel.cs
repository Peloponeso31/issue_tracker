using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;
using System.Windows.Controls;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas
{
    public class PestanaSenasParticularesViewModel
    {
        public ObservableCollection<senasParticulares> dataRegis { get; set; }
        public string newRegionCuerpo { get; set; }
        public string newTipo { get; set; }
        public string newLado { get; set; }
        public string newVista { get; set; }
        public int newCantidad { get; set; }
        public string newDescripcion { get; set; }
        public ICommand commandGuardar { get; set; }

        public PestanaSenasParticularesViewModel() 
        {
            dataRegis = new ObservableCollection<senasParticulares>();
            commandGuardar = new DelegateCommand(guaradarRegistro);
        }

        private void guaradarRegistro()
        {
            /* Guia de los datos que faltan por registrar
            int no = dataTableCounter;
          X string region = textBox1.Text;
          X string tipo = comboBox1.Text;
          X string lado = comboBox2.Text;
          X string vista = comboBox3.Text;
          X string cantidad = comboBox4.Text;
          X string descripcion = DescriptionBox.Text;
            string rutaImagen = pictureBox4.Tag as string;
            string coordenadas = globalRGB;
            */

            // Crear un nuevo objeto caracDato y agregarlo a la colección
            dataRegis.Add(new senasParticulares { parteText = newRegionCuerpo, 
                                                  tipoText = newTipo, 
                                                  ladoText = newLado, 
                                                  vistaText = newVista, 
                                                  cantidadText = newCantidad, 
                                                  descripcionText = newDescripcion,
                                                  //RutaImagen = rutaImagen, Coordenadas = coordenadas
            });
        }
    }
}
