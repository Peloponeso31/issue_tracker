using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Ubicaciones
{
    public class CatalogoData
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public override string ToString()
        {
            return nombre;
        }
    }

    public class Catalogos
    {
        public List<CatalogoData> data { get; set; }
    }
}
