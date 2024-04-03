using System.Collections.Generic;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Informaciones;

public class MedioData
{
    public int id { get; set; }
    public int tipo_medio_id { get; set; }
    public string nombre { get; set; }

    public override string ToString()
    {
        return nombre;
    }
}

public class Medios
{
    public List<MedioData> data { get; set; }
}