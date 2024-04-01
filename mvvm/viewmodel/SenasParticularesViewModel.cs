using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel
{
    internal class SenasParticularesViewModel
    {

        public class caracDato //Caracteristicas de los datos para la tabla
        {
            public int No { get; set; }
            public string Region { get; set; }
            public string Tipo { get; set; }
            public string Lado { get; set; }
            public string Vista { get; set; }
            public string Cantidad { get; set; }
            public string Descripcion { get; set; }
            public string RutaImagen { get; set; }
            public string Coordenadas { get; set; }
        }

        public class Traslado
        {
            public string TextBox1 { get; set; }
            public string ComboBox1 { get; set;}
            public string ComboBox2 { get; set;}
            public string ComboBox3 { get; set;}
            public string ComboBox4 { get; set;}
            public string DescriptionBox { get; set; }
            public string PictureBox4 { get; set; }
        }
    }
}
