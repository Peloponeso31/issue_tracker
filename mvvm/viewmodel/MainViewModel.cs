using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand InicioRelayCommand { get; set; }
        public RelayCommand BusquedaRelayCommand { get; set; }

        public InicioViewModel PantallaInicio{ get; set; }
		public BusquedaViewModel PantallaBusqueda { get; set; }

        private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set {
				this._currentView = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel()
		{
			PantallaInicio = new InicioViewModel();
			PantallaBusqueda = new BusquedaViewModel();

			CurrentView = PantallaInicio;

            InicioRelayCommand = new RelayCommand(o => {
                CurrentView = PantallaInicio;
            });

            BusquedaRelayCommand = new RelayCommand(o => {
                CurrentView = PantallaBusqueda;
            });
        }
	}
}
