using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects
{
    internal class HechosDesaparicion
    {
        public int id { get; set; }
        public int reporte_id { get; set; }
        public object cambio_comportamiento { get; set; }
        public string descripcion_cambio_comportamiento { get; set; }
        public object fue_amenazado { get; set; }
        public string descripcion_amenaza { get; set; }
        public object contador_desapariciones { get; set; }
        public string situacion_previa { get; set; }
        public string informacion_relevante { get; set; }
        public string hechos_desaparicion { get; set; }
        public string sintesis_desaparicion { get; set; }
        public object created_at { get; set; }
        public object updated_at { get; set; }
    }
}
