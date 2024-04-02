using System.ComponentModel;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model
{
    public class senasParticulares : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _parteText;
        public string parteText
        {
            get{return _parteText;}
            set
            {
                _parteText = value;
                OnPropertyChanged(nameof(parteText));
            }
        }

        private string _tipoText;
        public string tipoText
        {
            get
            {
                return _tipoText;
            }
            set
            {
                _tipoText = value;
                OnPropertyChanged(nameof(tipoText));
            }
        }

        private string _ladoText;
        public string ladoText
        {
            get
            {
                return _ladoText;
            }
            set
            {
                _ladoText = value;
                OnPropertyChanged(nameof(ladoText));
            }
        }

        private string _vistaText;
        public string vistaText
        {
            get
            {
                return _vistaText;
            }
            set
            {
                _vistaText = value;
                OnPropertyChanged(nameof(vistaText));
            }
        }

        private int _cantidadText;
        public int cantidadText
        {
            get
            {
                return _cantidadText;
            }
            set
            {
                _cantidadText = value;
                OnPropertyChanged(nameof(cantidadText));
            }
        }

        private string _descripcionText;
        public string descripcionText
        {
            get
            {
                return _descripcionText;
            }
            set
            {
                _descripcionText = value;
                OnPropertyChanged(nameof(descripcionText));
            }
        }
    }
}
