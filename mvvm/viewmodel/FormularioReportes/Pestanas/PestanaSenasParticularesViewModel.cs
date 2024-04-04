using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas
{
    public class PestanaSenasParticularesViewModel : ObservableObject
    {
		private string _colorRegionCuerpo;
		public string ColorRegionCuerpo
		{
			get
			{
				return _colorRegionCuerpo;
			}
			set
			{
                _colorRegionCuerpo = value.Substring(3);
				Console.WriteLine($"Color Region: {_colorRegionCuerpo}");
				OnPropertyChanged();
			}
		}

        private string _colorLado;
        public string ColorLado
        {
            get
            {
                return _colorLado;
            }
            set
            {
                _colorLado = value.Substring(3);
                Console.WriteLine($"Color lado: {_colorLado}");
                OnPropertyChanged();
            }
        }

        private Dictionary<string, RegionCuerpo> _regionCuerpo;
		public Dictionary<string, RegionCuerpo> RegionCuerpo
		{
			get
			{
				return _regionCuerpo;
			}
			set
			{
				_regionCuerpo = value;
				OnPropertyChanged(nameof(RegionCuerpo));
			}
		}


        private Dictionary<string, TipoSenas> _tipoSenas;
        public Dictionary<string, TipoSenas> TipoSenas
        {
            get
            {
                return _tipoSenas;
            }
            set
            {
                _tipoSenas = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<string, LadoSenas> _ladoSenas;
        public Dictionary<string, LadoSenas> LadoSenas
        {
            get
            {
                return _ladoSenas;
            }
            set
            {
                _ladoSenas = value;
                OnPropertyChanged();
            }
        }
        public PestanaSenasParticularesViewModel()
        {
			CargarCatalogos();
        }

        public async void CargarCatalogos()
        {
            var regiones_cuerpo = await HttpClientHandler.GetRegionCuerpo();
            RegionCuerpo = (Dictionary<string, RegionCuerpo>)regiones_cuerpo;

            var tipo = await HttpClientHandler.GetTipo();
            TipoSenas = (Dictionary<string, TipoSenas>)tipo;

            var lado = await HttpClientHandler.GetLado();
            LadoSenas = (Dictionary<string, LadoSenas>)lado;
        }

    }
}
