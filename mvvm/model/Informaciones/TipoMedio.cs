using System.Collections.Generic;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Informaciones;

public class TipoMedioData
{
    public int id { get; set; }
    public string nombre { get; set; }

    public override string ToString()
    {
        return nombre;
    }
}

public class TiposMedios
{
    public List<TipoMedioData> data { get; set; }
}