using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects
{
    public class UserData
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public DateTime email_verified_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
    public class User : CorrectResponse
    {
        public UserData data {  get; set; }
    }
}
