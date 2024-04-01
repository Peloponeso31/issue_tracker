﻿using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.viewmodel
{
    class OtraPestanaViewModel : ObservableObject
    {
        private readonly TestViewModel testViewModel;
        public OtraPestanaViewModel(TestViewModel testViewModel)
        {
            this.testViewModel = testViewModel;
        }
    }
}
