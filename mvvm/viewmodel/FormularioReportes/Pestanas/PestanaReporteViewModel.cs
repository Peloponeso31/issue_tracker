using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Ubicaciones;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas
{
    class PestanaReporteViewModel : ObservableObject
    {
        private readonly FormularioReportesViewModel _formularioReportesViewModel;
        public PestanaReporteViewModel(FormularioReportesViewModel formularioReportesViewModel)
        {
            this._formularioReportesViewModel = formularioReportesViewModel;
            CargarEstado();
        }

        private Dictionary<string, EstadoData> _estados;
        public Dictionary<string, EstadoData> Estados
        {
            get
            {
                return _estados;
            }
            set
            {
                _estados = value;
                OnPropertyChanged();
            }
        }

        public async void CargarEstado()
        {
            var estados = await HttpClientHandler.GetEstados();
            Estados = (Dictionary<string, EstadoData>)estados;
        }
    }
}
