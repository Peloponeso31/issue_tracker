using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects
{

    public class Reportante
    {
        public int id { get; set; }
        public int reporte_id { get; set; }
        public PersonaData persona { get; set; }
        public int parentesco_id { get; set; }
        public bool denuncia_anonima { get; set; }
        public bool informacion_consentimiento { get; set; }
        public bool informacion_exclusiva_busqueda { get; set; }
        public bool publicacion_registro_nacional { get; set; }
        public bool publicacion_boletin { get; set; }
        public bool pertenencia_colectivo { get; set; }
        public string nombre_colectivo { get; set; }
        public string informacion_relevante { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class Desaparecido
    {
        public int id { get; set; }
        public int reporte_id { get; set; }
        public PersonaData persona { get; set; }
        public bool habla_espanhol { get; set; }
        public bool sabe_leer { get; set; }
        public bool sabe_escribir { get; set; }
        public string url_boletin { get; set; }
        public object folio { get; set; }
    }
    public class ReporteData
    {
        public int id { get; set; }
        public int tipo_reporte_id { get; set; }
        public int area_atiende_id { get; set; }
        public int medio_conocimiento_id { get; set; }
        public int zona_estado_id { get; set; }
        public int hipotesis_oficial_id { get; set; }
        public string tipo_desaparicion { get; set; }
        public object fecha_localizacion { get; set; }
        public object sintesis_localizacion { get; set; }
        public object clasificacion_persona { get; set; }
        public List<Reportante> reportantes { get; set; }
        public List<Desaparecido> desaparecidos { get; set; }
    }
    
    public class Reporte
    {
        public List<ReporteData> data { get; set; }
    }
}
