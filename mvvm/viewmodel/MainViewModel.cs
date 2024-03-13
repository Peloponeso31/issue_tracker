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
        public RelayCommand SenasParticularesCommand { get; set; }
        public RelayCommand CapturaRelayCommand { get; set; }
        public RelayCommand TestRelayCommand { get; set; }

        public InicioViewModel PantallaInicio { get; set; }
        public BusquedaViewModel PantallaBusqueda { get; set; }
        public SenasParticularesViewModel PantallaSenasParticulares { get; set; }
        public CapturaViewModel PantallaCaptura { get; set; }
        public TestViewModel PantallaTest { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                this._currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PantallaInicio = new InicioViewModel();
            PantallaBusqueda = new BusquedaViewModel();
            PantallaCaptura = new CapturaViewModel();
            PantallaSenasParticulares = new SenasParticularesViewModel();
            PantallaTest = new TestViewModel();

            CurrentView = PantallaInicio;

            InicioRelayCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaInicio;
            });

            BusquedaRelayCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaBusqueda;
            });

            SenasParticularesCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaSenasParticulares;
            });

            CapturaRelayCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaCaptura;
            });

            TestRelayCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaTest;
            });
        }
    }
}
