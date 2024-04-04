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

		public async void CargarCatalogos()
		{
            var regiones_cuerpo = await HttpClientHandler.GetRegionCuerpo();
			RegionCuerpo = (Dictionary<string, RegionCuerpo>)regiones_cuerpo;
        }


    }
}
