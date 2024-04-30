using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
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
        private readonly PestanaReportanteViewModel _pestanaReportante;
        private readonly PestanaPersonaDesaparecidaViewModel _pestanaPersonaDesaparecida;
        private readonly PestanaPrendaDeVestirViewModel _pestanaPrenda;
        private readonly PestanaCondicionesVulnerabilidadViewModel _pestanaCondiciones;
        private readonly PestanaHechosDesaparicionViewModel _pestanaHechos;
        private readonly PestanaLocalizacionViewModel _pestanaLocalizacion;
        private readonly PestanaContextoViewModel _pestanaContexto;
        private readonly PestanaControlOGPIViewModel _pestanaControl;
        private readonly PestanaMediaAfilacionViewModel _pestanamediaAfilacion;

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
        public RelayCommand PestanaReportanteRelayCommand { get; set; }
        public RelayCommand PestanaPersonaDesaparecidaRelayCommand { get; set; }
        public RelayCommand PestanaPrendaDeVestirRelayCommand { get; set; }
        public RelayCommand PestanaCondicionesVulnerabilidadRelayCommand { get; set; }
        public RelayCommand PestanaHechosDesaparicionRelayCommand { get; set; }
        public RelayCommand PestanaLocalizacionRelayCommand { get; set; }
        public RelayCommand PestanaContextoRelayCommand { get; set; } 
        public RelayCommand PestanaControlOGPIRelayCommand { get; set; }
        public RelayCommand PestanaMediaAfilacionRelayCommand { get; set; }


        public FormularioReportesViewModel()
        {
            _pestanaReporte = new PestanaReporteViewModel(this);
            _pestanaSenasParticulares = new PestanaSenasParticularesViewModel(this);
            _pestanaReportante = new PestanaReportanteViewModel(this);
            _pestanaPersonaDesaparecida = new PestanaPersonaDesaparecidaViewModel(this);
            _pestanaPrenda = new PestanaPrendaDeVestirViewModel(this);
            _pestanaCondiciones = new PestanaCondicionesVulnerabilidadViewModel(this);
            _pestanaHechos = new PestanaHechosDesaparicionViewModel(this);
            _pestanaLocalizacion = new PestanaLocalizacionViewModel(this);
            _pestanaContexto = new PestanaContextoViewModel(this);
            _pestanaControl = new PestanaControlOGPIViewModel(this);
            _pestanamediaAfilacion = new PestanaMediaAfilacionViewModel(this);

            PestanaActual = _pestanaReporte;

            PestanaReporteRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaReporte;
            });

            PestanaSenasParticularesRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaSenasParticulares;
            });

            PestanaReportanteRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaReportante;
            });

            PestanaPersonaDesaparecidaRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaPersonaDesaparecida;
            });

            PestanaPrendaDeVestirRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaPrenda;
            });
            
            PestanaCondicionesVulnerabilidadRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaCondiciones;
            });

            PestanaHechosDesaparicionRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaHechos;
            });

            PestanaLocalizacionRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaLocalizacion;
            });

            PestanaContextoRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaContexto;
            });

            PestanaControlOGPIRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanaControl;
            });

            PestanaMediaAfilacionRelayCommand = new RelayCommand(o =>
            {
                PestanaActual = _pestanamediaAfilacion;
            });
        }
    }
}
