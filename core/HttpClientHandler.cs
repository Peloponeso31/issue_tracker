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
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.core.requestObjects.errorObjects;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.FormularioReportes.SenasParticulares;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Informaciones;
using Comisión_Estatal_de_Búsqueda_del_Estado_de_Veracruz.mvvm.model.Ubicaciones;

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

        public static async Task<Object> GetEstados()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/estados");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Estados estados = JsonSerializer.Deserialize<Estados>(jsonResponse);
            Dictionary<string, EstadoData> dic = new Dictionary<string, EstadoData>();

            foreach (var estado in estados.data)
            {
                dic.Add(estado.id, estado);
            }

            return dic;
        }

        public static async Task<object> GetTiposMedios()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/tipos-medios");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            TiposMedios tiposMedios = JsonSerializer.Deserialize<TiposMedios>(jsonResponse);
            Dictionary<int, TipoMedioData> dic = new Dictionary<int, TipoMedioData>();

            foreach (var tipoMedio in tiposMedios.data)
            {
                dic.Add(tipoMedio.id, tipoMedio);
            }

            return dic;
        }
        
        public static async Task<object> GetMedios()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/medios");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            Medios medios = JsonSerializer.Deserialize<Medios>(jsonResponse);
            Dictionary<int, MedioData> dic = new Dictionary<int, MedioData>();

            foreach (var medio in medios.data)
            {
                dic.Add(medio.id, medio);
            }

            return dic;
        }

        public static async Task<object> GetTiposReportes()
        {
            using HttpResponseMessage response = await sharedClient.GetAsync($"api/tipos-reportes");
            var jsonResponse = await response.Content.ReadAsStringAsync();

            TiposReportes tiposReportes = JsonSerializer.Deserialize<TiposReportes>(jsonResponse);
            Dictionary<int, TipoReporteData> dic = new Dictionary<int, TipoReporteData>();

            foreach (var tipoReporte in tiposReportes.data)
            {
                dic.Add(tipoReporte.id, tipoReporte);
            }

            return dic;
        }

        public static async Task<object> PostReporte(int tipoReporte_id, int? area_atiende_id = null, int? medio_conocimiento_id = null, int? zona_estado_id = null, int? hipotesis_oficial_id = null, string tipo_desaparicion = "U", object? fecha_localizacion = null, object? sintesis_localizacion = null, object? clasificacion_persona = null)
        {
            ReporteData reporteData = new ReporteData
            {
                tipo_reporte_id = tipoReporte_id,
                area_atiende_id = area_atiende_id,
                medio_conocimiento_id = medio_conocimiento_id,
                zona_estado_id = zona_estado_id,
                hipotesis_oficial_id = hipotesis_oficial_id,
                tipo_desaparicion = tipo_desaparicion,
                fecha_localizacion = fecha_localizacion,
                sintesis_localizacion = sintesis_localizacion,
                clasificacion_persona = clasificacion_persona,
            };

            string json = JsonSerializer.Serialize(reporteData);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await sharedClient.PostAsync("api/reportes", content);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            if ((int) response.StatusCode == 201)
            {
                Console.WriteLine("Exito al crear reporte");
                return null;
            }
            
            Console.WriteLine("Error al crear reporte");

            return null;
        }
    }
}
