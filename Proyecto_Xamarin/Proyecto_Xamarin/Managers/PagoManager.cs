using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto_Xamarin.Models;

namespace Proyecto_Xamarin.Managers
{
    public class PagoManager
    {
        const string Url = "https://www.gruposama.com/WebApiSecureSAMA/api/pago/";
        const string UrlIngresar = Url + "ingresar/";

        public async Task<IEnumerable<Pago>> GetPagos()
        {

            HttpClient client = new HttpClient();
           
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Pago>>(result);
        }

        public async Task<Pago> Ingresar(Pago pago)
        {

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(UrlIngresar,
                new StringContent(JsonConvert.SerializeObject(pago),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Pago>(await
            response.Content.ReadAsStringAsync());
        }


        public PagoManager()
        {
        }
    }
}
