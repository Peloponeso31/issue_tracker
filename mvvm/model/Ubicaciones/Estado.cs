using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Ubicaciones
{

    public class EstadoData
    {
        public string id { get; set; }
        public string nombre { get; set; }
        public string abreviatura_inegi { get; set; }
        public string abreviatura_cebv { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }
    public class Estados
    {
        public List<EstadoData> data { get; set; }
    }
}
