﻿using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes.Pestanas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.FormularioReportes
{
    public class FormularioReportesViewModel : ObservableObject
    {
        private readonly PestanaReporteViewModel _pestanaReporte;
        private readonly PestanaSenasParticularesViewModel _pestanaSenasParticulares;

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
				OnPropertyChanged();
			}
		}

		public RelayCommand PestanaReporteRelayCommand { get; set; }
		public RelayCommand PestanaSenasParticularesRelayCommand { get; set; }


        public FormularioReportesViewModel()
        {
            _pestanaReporte = new PestanaReporteViewModel(this);
			_pestanaSenasParticulares = new PestanaSenasParticularesViewModel(this);

			PestanaActual = _pestanaReporte;

			PestanaReporteRelayCommand = new RelayCommand(o =>
			{
				PestanaActual = _pestanaReporte;
			});

            PestanaSenasParticularesRelayCommand = new RelayCommand(o =>
            {
				PestanaActual = _pestanaSenasParticulares;
            });
        }
    }
}
