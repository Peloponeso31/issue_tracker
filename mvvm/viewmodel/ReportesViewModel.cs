using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel
{
    public class ReportesViewModel : ObservableObject 
    {
        private readonly MainViewModel _mainViewModel;

        private Reporte _reportes;
        public Reporte Reportes
        {
            get
            {
                return _reportes;
            }
            set
            {
                _reportes = value;
                OnPropertyChanged(nameof(Reportes));
            }
        }

        public RelayCommand CaprutarRelayCommand { get; set; }

        public ReportesViewModel(MainViewModel mainViewModel)
        {
            CargarAsync();
            _mainViewModel = mainViewModel;

            CaprutarRelayCommand = new RelayCommand(o =>
            {
                _mainViewModel.CurrentView = new FormularioReportesViewModel();
            });
        }

        private async void CargarAsync()
        {
            Reportes = await HttpClientHandler.GetReportes();
        }
    }
}
