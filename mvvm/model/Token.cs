using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model
{
    public class TokenData
    { 
        public string? plain_text_token { get; set; }
        public string? token_name { get; set; } 
        public int? user_id { get; set; }
        public DateTime created_at { get; set; }
    }
    public class Token
    {
        public TokenData data { get; set; }
    }
}
