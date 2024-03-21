using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects
{
    internal class PersonaData
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public string? apellido_paterno { get; set; }
        public string? apellido_materno { get; set; }
        public string? fecha_nacimiento { get; set; }
        public string? curp { get; set; }
        public string? ocupacion { get; set; }
        public string? sexo { get; set; }
        public string? genero { get; set; }

        public override string ToString()
        {
            return $"{nombre} {apellido_paterno} {apellido_materno}";
        }
    }

    internal class Persona
    {
        public List<PersonaData> data { get; set; }
    }
}
