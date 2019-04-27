using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Xamarin.Models;
using Newtonsoft.Json;

namespace Proyecto_Xamarin.Managers
{
    public class CuentaManager
    {
        //const string Url = "http://192.168.0.7:45455/api/Cuenta/";

        //const string UrlIngresar = "http://192.168.0.7:45455/api/cuenta/ingresarCuenta/";
        //const string UrlUpdate = "http://192.168.0.7:45455/api/cuenta/Update/";
        //const string UrlEliminar = "http://192.168.0.7:45455/api/cuenta/Delete/";

        const string Url = "https://www.gruposama.com/WebApiSecureSAMA/api/cuenta/"; // U
        const string UrlIngresar = "https://www.gruposama.com/WebApiSecureSAMA/api/cuenta/ingresar/";
        const string UrlUpdate = "https://www.gruposama.com/WebApiSecureSAMA/api/Cuenta/";
        const string UrlEliminar = "https://www.gruposama.com/WebApiSecureSAMA/api/Cuenta/";

        public async Task<IEnumerable<Cuenta>> GetCuentas(string id)
        {

            HttpClient client = new HttpClient();

            string result = await client.GetStringAsync(Url + id);
            return JsonConvert.DeserializeObject<IEnumerable<Cuenta>>(result);
        }

        public async Task<Cuenta> Ingresar(Cuenta cuenta)
        {

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(UrlIngresar,
                new StringContent(JsonConvert.SerializeObject(cuenta),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Cuenta>(await
            response.Content.ReadAsStringAsync());
        }

        public async Task<Cuenta> Actualizar(Cuenta cuenta)
        {

            HttpClient client = new HttpClient();
            var response = await client.PutAsync(UrlUpdate,
                new StringContent(JsonConvert.SerializeObject(cuenta),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Cuenta>(await
            response.Content.ReadAsStringAsync());
        }

        public async Task<string> Eliminar(string id)
        {

            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync(UrlEliminar + id);

            return JsonConvert.DeserializeObject<string>(await
            response.Content.ReadAsStringAsync());
        }
      
    }
}
