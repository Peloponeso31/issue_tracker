using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
			_formularioReportesViewModel = formularioReportesViewModel;
			CargarCatalogos();
        }

		public ObservableCollection<SenasParticularesData> SenasParticularesData { get; set; }
        public ObservableCollection<SenasParticularesTabla> SenasParticularesTabla { get; set; }

        public RelayCommand GuardarRelayCommand { get; set; }

		public async void CargarCatalogos()
		{
            var regiones_cuerpo = await HttpClientHandler.GetRegionCuerpo();
			RegionCuerpo = (Dictionary<string, RegionCuerpo>)regiones_cuerpo;
			SenasParticularesData = new ObservableCollection<SenasParticularesData>();
			SenasParticularesTabla = new ObservableCollection<SenasParticularesTabla>();

			GuardarRelayCommand = new RelayCommand(o =>
			{
				SenasParticularesData senas = new SenasParticularesData(1, (int)RegionCuerpo[Color].id, 1, 1, 1, 1, "lorem ipsum", "https://www.url.com");
				SenasParticularesTabla.Add(new SenasParticularesTabla((string)RegionCuerpo[Color].nombre, "", "", "", 1, "", ""));
				SenasParticularesData.Add(senas);
			});

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