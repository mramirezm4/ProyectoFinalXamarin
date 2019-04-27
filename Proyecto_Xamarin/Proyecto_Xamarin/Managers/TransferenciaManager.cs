using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proyecto_Xamarin.Models;

namespace Proyecto_Xamarin.Managers
{
    class TransferenciaManager
    {
        const string URLRegistroTransferencia = "https://www.gruposama.com/WebApiSecureSAMA/api/transferencia/ingresar";
        const string URLListarTransferencia = "https://www.gruposama.com/WebApiSecureSAMA/api/transferencia";


        public async Task<IEnumerable<Transferencia>> GetTransferencias()
        {

            HttpClient client = new HttpClient();

            string result = await client.GetStringAsync(URLListarTransferencia);
            return JsonConvert.DeserializeObject<IEnumerable<Transferencia>>(result);
        }

        public async Task<Transferencia> Ingresar(Transferencia tran)
        {

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(URLRegistroTransferencia,
                new StringContent(JsonConvert.SerializeObject(tran),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Transferencia>(await
            response.Content.ReadAsStringAsync());
        }
    }
}
