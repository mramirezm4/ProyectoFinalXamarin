using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Proyecto_Xamarin.Models;
using Newtonsoft.Json;

namespace Proyecto_Xamarin.Managers
{
    public class ServicioManager
    {
        const string Url = "https://www.gruposama.com/WebApiSecureSAMA/api/servicio/"; // U

        public async Task<IEnumerable<Servicio>> GetServicios()
        {

            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Servicio>>(result);
        }

        public ServicioManager()
        {
        }
    }
}
