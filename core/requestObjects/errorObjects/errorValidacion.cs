using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects.errorObjects
{
    public class ErrorValidacion : Error
    {
        public string? causa { get; set; }
        public Dictionary<string, List<string>> campos_faltantes { get; set; }
    }
}
