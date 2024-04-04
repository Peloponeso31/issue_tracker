using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Ubicaciones;
using System.Collections.Generic;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Informaciones;

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

        /**
         * Catalogo de Medios
         */
        private Dictionary<int, TipoMedioData> _tiposMedios;
        public Dictionary<int, TipoMedioData> TiposMedios
        {
            get
            {
                return _tiposMedios;
            }
            set
            {
                _tiposMedios = value;
                OnPropertyChanged();
            }
        }
        
        private Dictionary<int, MedioData> _medios;
        public Dictionary<int, MedioData> Medios
        {
            get
            {
                return _medios;
            }
            set
            {
                _medios = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<int, TipoReporteData> _tiposReportes;
        public Dictionary<int, TipoReporteData> TiposReportes
        {
            get
            {
                return _tiposReportes;
            }
            set
            {
                _tiposReportes = value;
                OnPropertyChanged();
            }
        }
        
        public async void CargarEstado()
        {
            var estados = await HttpClientHandler.GetEstados();
            Estados = (Dictionary<string, EstadoData>)estados;
            
            var tiposReportes = await HttpClientHandler.GetTiposReportes();
            TiposReportes = (Dictionary<int, TipoReporteData>)tiposReportes;

            var tiposMedios = await HttpClientHandler.GetTiposMedios();
            TiposMedios = (Dictionary<int, TipoMedioData>)tiposMedios;
            
            var medios = await HttpClientHandler.GetMedios();
            Medios = (Dictionary<int, MedioData>)medios;
        }
    }
}
