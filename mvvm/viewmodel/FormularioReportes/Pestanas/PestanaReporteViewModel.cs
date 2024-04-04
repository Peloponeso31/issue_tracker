using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Ubicaciones;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            CargarTipoRepor();
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

        public async void CargarEstado()
        {
            var estados = await HttpClientHandler.GetEstados();
            Estados = (Dictionary<string, EstadoData>)estados;

            var tiposMedios = await HttpClientHandler.GetTiposMedios();
            TiposMedios = (Dictionary<int, TipoMedioData>)tiposMedios;
            
            var medios = await HttpClientHandler.GetMedios();
            Medios = (Dictionary<int, MedioData>)medios;
        }


        private Dictionary<string, CatalogoData> _catalogos;
        public Dictionary<string, CatalogoData> Catalogos
        {
            get
            {
                return _catalogos;
            }
            set
            {
                _catalogos = value;
                OnPropertyChanged();
            }
        }

        public async void CargarTipoRepor()
        {
            var catalogos = await HttpClientHandler.GetTipoRepor();
            Catalogos = (Dictionary<string, CatalogoData>)catalogos;
        }
    }
}
