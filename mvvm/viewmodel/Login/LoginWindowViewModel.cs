using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel.Login
{
    public class LoginWindowViewModel : ObservableObject
    {
        private ObservableObject _currentViewModel;
		public ObservableObject CurrentViewModel
		{
			get
			{
				return _currentViewModel;
			}
			set
			{
				_currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}

		public RelayCommand CloseWindowCommand {  get; set; }
        public LoginWindowViewModel()
        {
            CurrentViewModel = new LoginViewModel(this);
        }
    }
}
