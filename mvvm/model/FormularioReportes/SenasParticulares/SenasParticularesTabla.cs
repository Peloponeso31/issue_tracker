using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares
{
    public class SenasParticularesTabla
    {
        public string region_cuerpo { get; set; }
        public string vista { get; set; }
        public string lado { get; set; }
        public string tipo { get; set; }
        public int cantidad { get; set; }
        public string descripcion { get; set; }
        public string foto { get; set; }

        public SenasParticularesTabla(string region_cuerpo, string vista, string lado, string tipo, int cantidad, string descripcion, string foto)
        {
            this.region_cuerpo = region_cuerpo;
            this.vista = vista;
            this.lado = lado;
            this.tipo = tipo;
            this.cantidad = cantidad;
            this.descripcion = descripcion;
            this.foto = foto;
        }
    }
}
