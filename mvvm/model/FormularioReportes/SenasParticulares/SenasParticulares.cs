using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares
{
    public class SenasParticularesData
    {
        public int persona_id { get; set; }
        public int region_cuerpo_id { get; set; }
        public int vista_id { get; set; }
        public int lado_id { get; set; }
        public int tipo_id { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public string foto { get; set; }

        public SenasParticularesData(int persona_id, int region_cuerpo_id, int vista_id, int lado_id, int tipo_id, int cantidad, string descripcion, string foto)
        {
            this.persona_id = persona_id;
            this.region_cuerpo_id = region_cuerpo_id;
            this.vista_id = vista_id;
            this.lado_id = lado_id;
            this.tipo_id = tipo_id;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.foto = foto;
        }
    }

    class SenasParticulares
    {
        public List<SenasParticularesData> data { get; set; }

        public static implicit operator SenasParticulares(SenasParticularesData v)
        {
            throw new NotImplementedException();
        }
    }
}
