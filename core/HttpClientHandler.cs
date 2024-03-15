using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects.errorObjects;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core
{
    internal class HttpClientHandler
    {
        private static HttpClient sharedClient = new()
        {
            // Cambiar a localhost para pruebas locales.
            BaseAddress = new Uri("http://192.168.56.1/"),
        };

        private static string NombreArchivoSanitizado(string nombre)
        {
            string patron = "[\\/:*?\"<>|]";
            return Regex.Replace(nombre, patron, "-");
        }

        public static async Task<Object> GetTokenRequest(string Usuario, string Password)
        {
            sharedClient.DefaultRequestHeaders.Add("Acept", "application/json");
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/token?email={Usuario}&password={Password}&token_name=escritorio.{System.Environment.MachineName}");
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
                    HttpResponseMessage authResponse = await sharedClient.GetAsync("api/user");
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

        public static async Task<string> GetReportePdf(string id)
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"reportes/informe_de_inicio/{id}");
            string headerValue = response.Content.Headers.GetValues("Content-Disposition").FirstOrDefault().ToString();
            string filename = new ContentDisposition(headerValue).FileName;
            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string ruta = Path.Combine(documentos, NombreArchivoSanitizado(filename)); 
            byte[] archivo = await response.Content.ReadAsByteArrayAsync();
            await File.WriteAllBytesAsync(ruta, archivo);
            return ruta;
        }

        public static async Task<Reporte> GetReportes()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/reportes");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Reporte reportes = JsonSerializer.Deserialize<Reporte>(jsonResponse);
            return reportes;
        }
    }
}
