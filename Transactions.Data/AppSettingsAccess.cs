using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transactions.Data
{
    public class AppSettingsAccess
    {
        IConfiguration Configuration { get; set; }
        public AppSettingsAccess(string basePath)
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(basePath)
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();
        }
        public string ApiUrl => Configuration["ApiUrl"];
        public string CrearClienteUrl => Configuration["CrearClienteUrl"];
        public string GetClienteByNameUrl => Configuration["GetClienteByNameUrl"];
        public string CrearCuentaUrl => Configuration["CrearCuentaUrl"];
        public string GetCuentaByNameAndCuentaTipoUrl => Configuration["GetCuentaByNameAndCuentaTipoUrl"];
        public string CrearMovimientoUrl => Configuration["CrearMovimientoUrl"];
        public string GetReporteByClienteFechaUrl => Configuration["GetReporteByClienteFecha"];



    }
}
