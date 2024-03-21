using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects
{
    internal class ReporteData
    {
        public int id { get; set; }
        public int area_id { get; set; }
        public string zona_estado { get; set; }
        public int medio_id { get; set; }
        public object tipo_desaparicon { get; set; }
        public string estatus { get; set; }
        public string fecha_desaparicion { get; set; }
        public string fecha_percato { get; set; }
        public string folio { get; set; }
        public int hechos_desaparicion_id { get; set; }
        public DateTime creado { get; set; }
        public List<PersonaData> reportante { get; set; }
        public List<PersonaData> desaparecido { get; set; }
    }
    
    internal class Reporte
    {
        public List<ReporteData> data { get; set; }
    }
}
