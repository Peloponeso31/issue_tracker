using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel
{
    internal class TestViewModel : ObservableObject
    {
		public readonly PestanaReporteViewModel PestanaReporte;
		public readonly OtraPestanaViewModel OtraPestana;
		
		public RelayCommand ReportesRelayCommand { get; set; }
        public RelayCommand OtraPestanaRelayCommand { get; set; }
        private ObservableObject _pestanaActual;
		public ObservableObject PestanaActual
		{
			get
			{
				return _pestanaActual;
			}
			set
			{
				_pestanaActual = value;
				OnPropertyChanged(nameof(PestanaActual));
			}
		}

        public TestViewModel()
        {
			PestanaReporte = new PestanaReporteViewModel(this);
			OtraPestana = new OtraPestanaViewModel(this);
			PestanaActual = PestanaReporte;

			ReportesRelayCommand = new RelayCommand(o => 
			{
				PestanaActual = PestanaReporte;
			});

            OtraPestanaRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = OtraPestana;
            });
        }
    }
}
