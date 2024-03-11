using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects.errorObjects;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core
{
    internal class HttpClientHandler
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://187.188.213.206:18080/api/"),
        };

        public static async Task<Object> GetTokenRequest(string Usuario, string Password)
        {
            sharedClient.DefaultRequestHeaders.Add("Acept", "application/json");
            using HttpResponseMessage response = await sharedClient.GetAsync($"token?email={Usuario}&password={Password}&token_name=escritorio.{System.Environment.MachineName}");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var request = response.RequestMessage;

            Debug.WriteLine((int)response.StatusCode);
            Debug.WriteLine(request.RequestUri);

            switch ((int) response.StatusCode)
            {
                // Request OK
                case 200:
                    Debug.WriteLine(jsonResponse);
                    Token token = JsonSerializer.Deserialize<Token>(jsonResponse);
                    sharedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.data.plain_text_token);
                    HttpResponseMessage authResponse = await sharedClient.GetAsync("user");
                    jsonResponse = await authResponse.Content.ReadAsStringAsync();
                    User usuario = JsonSerializer.Deserialize<User>(jsonResponse)!;
                    return usuario;

                // Unauthorized
                case 401:
                    Debug.WriteLine(jsonResponse);
                    Error error = JsonSerializer.Deserialize<Error>(jsonResponse)!;
                    Debug.WriteLine("error: " + error.error);
                    return error;
                    
                // Unprocesable content
                case 422:
                    ErrorValidacion error_val = JsonSerializer.Deserialize<ErrorValidacion>(jsonResponse)!;
                    Debug.WriteLine("error: "+error_val.error);
                    Debug.WriteLine("causa: "+error_val.causa);
                    foreach (KeyValuePair<string, List<string>> kvp in error_val.campos_faltantes) {
                        Debug.WriteLine("Key: {0} Value: {1}", kvp.Key, kvp.Value[0]);
                    }
                    //Debug.WriteLine("campos: "+error.campos_faltantes);
                    return error_val;
            }

            return null;
        }
    }
}
