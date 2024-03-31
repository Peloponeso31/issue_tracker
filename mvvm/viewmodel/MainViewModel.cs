using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;

using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel
{
    public class MainViewModel : ObservableObject
    {
        public RelayCommand InicioRelayCommand { get; set; }
        public RelayCommand BusquedaRelayCommand { get; set; }

        public InicioViewModel PantallaInicio { get; set; }
        public BusquedaViewModel PantallaBusqueda { get; set; }
        public ReportesViewModel PantallaReportes{ get; set; }

        public RelayCommand TestRelayCommand { get; set; }

        private ObservableObject _currentView;
        public ObservableObject CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                Console.WriteLine(nameof(CurrentView));
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public MainViewModel()
        {
            PantallaInicio = new InicioViewModel();
            PantallaBusqueda = new BusquedaViewModel();

            PantallaReportes = new ReportesViewModel(this);

            CurrentView = PantallaInicio;

            InicioRelayCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaInicio;
            });

            BusquedaRelayCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaBusqueda;
            });

            TestRelayCommand = new RelayCommand(o =>
            {
                CurrentView = PantallaReportes;
            });
        }
    }
}
