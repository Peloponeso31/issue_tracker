using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;

using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.view;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
        public PestanaSenasParticularesViewModel PantallaSenasParticulares { get; set; }
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

        private ObservableCollection<PhoneNumber> _phoneNumbers = new ObservableCollection<PhoneNumber>();
        public ObservableCollection<PhoneNumber> PhoneNumbers
        {
            get { return _phoneNumbers; }
            set
            {
                if (_phoneNumbers != value)
                {
                    _phoneNumbers = value;
                    OnPropertyChanged(nameof(PhoneNumbers));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand AddPhoneNumberCommand { get; }
        public MainViewModel()
        {
            PantallaInicio = new InicioViewModel();
            PantallaBusqueda = new BusquedaViewModel();
            PantallaCaptura = new CapturaViewModel();
            AddPhoneNumberCommand = new DelegateCommand(AddPhoneNumber);
            PantallaTest = new TestViewModel();
            PantallaSenasParticulares = new PestanaSenasParticularesViewModel();

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

        private void AddPhoneNumber()
        {
            PhoneNumbers.Add(new PhoneNumber());
        }
    }
}
