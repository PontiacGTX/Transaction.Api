using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Data;
using Transactions.Data.Common;
using Transactions.Data.HelperClass;
using Transactions.Data.Models;

namespace Transactions.Tests.Services
{
    public class ClienteServices
    {
        private readonly HttpClient _httpClient;
        private AppSettingsAccess _AppSettingsAccess { get; }
        public string RequestUrl(string basePath, string endpoint) => $"{basePath}{endpoint}";

        public ClienteServices(HttpClient httpClient)
        {
            string basePath = Directory.GetCurrentDirectory();
            basePath = FileHelper.CopyFileToDir(DirectoryHelper.GetNUpperDirectory(basePath, 4), basePath, "appsettings.json", @"\TestProjectAirline\");
            if (File.Exists(basePath))
            {
                basePath = DirectoryHelper.GetNUpperDirectory(basePath, 1);
            }
            _AppSettingsAccess = new AppSettingsAccess(basePath);
            _httpClient = httpClient;
        }

        public async Task<Response> CrearCuenta(CrearCuentaModel model)
        {
            Response response;
            try
            {
                var url = RequestUrl(_AppSettingsAccess.ApiUrl, _AppSettingsAccess.CrearCuentaUrl);
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(model);
                HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                response = JsonConvert.DeserializeObject<Response>(await responseMessage.Content.ReadAsStringAsync());
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Response> GetMovimientos(string idCliente,DateTime fecha)
        {
            Response response;
            try
            {
                var url = RequestUrl(_AppSettingsAccess.ApiUrl, _AppSettingsAccess.GetReporteByClienteFechaUrl.Replace("cliId",idCliente).Replace("fchaIni",fecha.Date.ToString()));
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
                response = JsonConvert.DeserializeObject<Response>(await responseMessage.Content.ReadAsStringAsync());
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Response> CrearCliente(CrearClienteModel model)
        {
            Response response;
            try
            {
                var url = RequestUrl(_AppSettingsAccess.ApiUrl, _AppSettingsAccess.CrearClienteUrl);
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(model);
                HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                response = JsonConvert.DeserializeObject<Response>(await responseMessage.Content.ReadAsStringAsync());
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Response> CrearMovimiento(CrearMovimientoModel model)
        {
            Response response;
            try
            {
                var url = RequestUrl(_AppSettingsAccess.ApiUrl, _AppSettingsAccess.CrearMovimientoUrl);
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                string json = JsonConvert.SerializeObject(model);
                HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
                response = JsonConvert.DeserializeObject<Response>(await responseMessage.Content.ReadAsStringAsync());
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Response> GetClienteByName(string nombre)
        {
            Response response;
            try
            {
                var url = RequestUrl(_AppSettingsAccess.ApiUrl, _AppSettingsAccess.GetClienteByNameUrl+nombre);
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
                response = JsonConvert.DeserializeObject<Response>(await responseMessage.Content.ReadAsStringAsync());
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        } 
        public async Task<Response> GetCuentaByNameAndTipoCuenta(string nombre,int tipoCuentaId)
        {
            Response response;
            try
            {
                var url = RequestUrl(_AppSettingsAccess.ApiUrl, _AppSettingsAccess.GetCuentaByNameAndCuentaTipoUrl.Replace("{nombreCliente}",nombre).Replace("tipoCuentaId",tipoCuentaId.ToString()));
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
                response = JsonConvert.DeserializeObject<Response>(await responseMessage.Content.ReadAsStringAsync());
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
