using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
            using HttpResponseMessage response = await sharedClient.GetAsync($"issue-token?email={Usuario}&password={Password}&token_name=escritorio.{System.Environment.MachineName}");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var request = response.RequestMessage;

            Debug.WriteLine(request.RequestUri);

            switch ((int)response.StatusCode)
            {
                case 200:
                    requestObjects.Token token = JsonSerializer.Deserialize<requestObjects.Token>(jsonResponse)!;
                    Debug.WriteLine(token.plainTextToken);
                    sharedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.plainTextToken);
                    HttpResponseMessage authResponse = await sharedClient.GetAsync("user");
                    jsonResponse = await authResponse.Content.ReadAsStringAsync();
                    requestObjects.User usuario = JsonSerializer.Deserialize<requestObjects.User>(jsonResponse)!;
                    return usuario;

                case 422:
                    requestObjects.errorObjects.errorValidacion error = JsonSerializer.Deserialize<requestObjects.errorObjects.errorValidacion>(jsonResponse)!;
                    Debug.WriteLine("error: "+error.error);
                    Debug.WriteLine("causa: "+error.causa);
                    //Debug.WriteLine("campos: "+error.campos_faltantes);
                    return error;
                    break;
            }

            return null;
        }
    }
}
