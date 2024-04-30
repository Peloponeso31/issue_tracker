using System;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Ubicaciones;
using System.Collections.Generic;
using System.Threading.Tasks;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Informaciones;
using static Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.HttpClientHandler;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas
{
    class PestanaReporteViewModel : ObservableObject
    {
        private readonly FormularioReportesViewModel _formularioReportesViewModel;

        public RelayCommand GuardarReporteCommand { set; get; }

        public PestanaReporteViewModel(FormularioReportesViewModel formularioReportesViewModel)
        {
            this._formularioReportesViewModel = formularioReportesViewModel;
            CargarEstado();
            GuardarReporteCommand = new RelayCommand(GuardarReporte);
        }

        private async void GuardarReporte(object o)
        {
            await PostReporte(TipoReporteSelecionado.Value.id, medio_conocimiento_id: MedioSeleccionado.Value.id);
        }
        
        private Dictionary<string, EstadoData> _estados;

        public Dictionary<string, EstadoData> Estados
        {
            get { return _estados; }
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
            get { return _tiposMedios; }
            set
            {
                _tiposMedios = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<int, MedioData> _medios;

        public Dictionary<int, MedioData> Medios
        {
            get { return _medios; }
            set
            {
                _medios = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<int, TipoReporteData> _tiposReportes;

        public Dictionary<int, TipoReporteData> TiposReportes
        {
            get { return _tiposReportes; }
            set
            {
                _tiposReportes = value;
                OnPropertyChanged();
            }
        }

        private KeyValuePair<int, TipoReporteData> _tipoReporteSeleccionado;
        public KeyValuePair<int, TipoReporteData> TipoReporteSelecionado
        {
            get { return _tipoReporteSeleccionado; }
            set
            {
                _tipoReporteSeleccionado = value;
                Console.WriteLine(TipoReporteSelecionado.Value.id);
                OnPropertyChanged();
            }
        }
        
        private KeyValuePair<int, MedioData> _medioSeleccionado;

        public KeyValuePair<int, MedioData> MedioSeleccionado
        {
            get { return _medioSeleccionado; }
            set
            {
                _medioSeleccionado = value;
                Console.WriteLine(MedioSeleccionado.Value.id);
                OnPropertyChanged();
            }
        }
        
        public async void CargarEstado()
        {
            var estados = await GetEstados();
            Estados = (Dictionary<string, EstadoData>)estados;

            var tiposReportes = await GetTiposReportes();
            TiposReportes = (Dictionary<int, TipoReporteData>)tiposReportes;

            var tiposMedios = await GetTiposMedios();
            TiposMedios = (Dictionary<int, TipoMedioData>)tiposMedios;

            var medios = await GetMedios();
            Medios = (Dictionary<int, MedioData>)medios;
        }
    }
}