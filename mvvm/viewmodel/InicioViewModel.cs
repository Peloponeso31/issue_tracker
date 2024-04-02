using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel
{
    public class InicioViewModel : ObservableObject
    {
        public RelayCommand AddRelayCommand {  get; set; }
        public RelayCommand MostrarCaptura { get; set; }
        public RelayCommand MostrarInicio { get; set; }
        private int _numero;
        public int Numero
        {
            get
            {
                return _numero;
            }
            set
            {
                _numero = value;
                OnPropertyChanged(nameof(Numero));
            }
        }

        private ObservableObject _currentSubView;
        public ObservableObject CurrentSubView
        {
            get
            {
                return _currentSubView;
            }
            set
            {
                _currentSubView = value;
                OnPropertyChanged(nameof(CurrentSubView));
            }
        }

        public InicioViewModel()
        {
            Numero = 0;
            AddRelayCommand = new RelayCommand(o =>
            {
                Numero += 1;
            });

            MostrarCaptura = new RelayCommand(o => {
                CurrentSubView = new CapturaViewModel();
            });

            MostrarInicio = new RelayCommand(o => {
                CurrentSubView = new InicioViewModel();
            });
        }
    }
}
