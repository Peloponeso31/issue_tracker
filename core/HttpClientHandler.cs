using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects.errorObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares;

namespace Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core
{
    internal class HttpClientHandler
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://187.251.212.146:18080/"),
        };

        private static string NombreArchivoSanitizado(string nombre)
        {
            string patron = "[\\/:*?\"<>|]";
            return Regex.Replace(nombre, patron, "-");
        }

        public static async Task<Object> GetTokenRequest(string Usuario, string Password)
        {
            sharedClient.DefaultRequestHeaders.Add("Accept", "application/json");
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/token?email={Usuario}&password={Password}&token_name=escritorio.{System.Environment.MachineName}");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            // OK
            if ((int)response.StatusCode == 200)
            {
                Token token = JsonSerializer.Deserialize<Token>(jsonResponse);
                sharedClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.data.plain_text_token);
                return token; // Devuelto por utilidad, ya que el token queda en los headers de la instancia estatica del manejador.
            }

            // Unauthorized
            else if ((int)response.StatusCode == 401)
            {
                Error error = JsonSerializer.Deserialize<Error>(jsonResponse);
                return error;
            }

            // Unprocesable content
            else if ((int)response.StatusCode == 422)
            {
                ErrorValidacion error_val = JsonSerializer.Deserialize<ErrorValidacion>(jsonResponse);
                return error_val;
            }

            return null;
        }

        public static async Task<Object> GetUsuarioActualRequest()
        {
            sharedClient.DefaultRequestHeaders.Add("Accept", "application/json");
            using HttpResponseMessage response = await sharedClient.GetAsync("api/usuario_actual");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if ((int) response.StatusCode == 200) 
            {
                User user = JsonSerializer.Deserialize<User>(jsonResponse);
                return user;
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

        public static async Task<Object> GetRegionCuerpo()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/catalogos/region_cuerpo");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<RegionCuerpo> regiones_cuerpo = JsonSerializer.Deserialize<List<RegionCuerpo>>(jsonResponse);
            Dictionary<string, RegionCuerpo> dic = new Dictionary<string, RegionCuerpo>();

            foreach (var region in regiones_cuerpo)
            {
                dic.Add(region.color, region);
            }

            return dic;
        }
        public static async Task<Object> GetTipo()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/catalogos/tipo");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<TipoSenas> tipo = JsonSerializer.Deserialize<List<TipoSenas>>(jsonResponse);
            Dictionary<string, TipoSenas> dic_tipo = new Dictionary<string, TipoSenas>();

            foreach (var tip in tipo)
            {
                dic_tipo.Add(tip.nombre, tip);
            }

            return dic_tipo;
        }

        public static async Task<Object> GetLado()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/catalogos/lado");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            List<LadoSenas> lado = JsonSerializer.Deserialize<List<LadoSenas>>(jsonResponse);
            Dictionary<string, LadoSenas> dic_lado = new Dictionary<string, LadoSenas>();

            foreach (var lad in lado)
            {
                dic_lado.Add(lad.color, lad);
            }

            return dic_lado;
        }
    }
}
