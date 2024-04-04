using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas
{
    public class PestanaSenasParticularesViewModel : ObservableObject
    {
		private FormularioReportesViewModel _formularioReportesViewModel;

		private string _color;
		public string Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value.Substring(3);
				Debug.WriteLine(_color);
				OnPropertyChanged(nameof(Color));
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

		public PestanaSenasParticularesViewModel(FormularioReportesViewModel formularioReportesViewModel)
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
        }
    }
}