using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Xamarin.Models;
using Newtonsoft.Json;

namespace Proyecto_Xamarin.Managers
{
    public class UsuarioManager
    {
        const string URL_BASE = "https://www.gruposama.com/WebApiSecureSAMA/api/LoginExt/";

        //const string UrlRegister = "http://localhost:56485/api/login/Register/";
        //const string URLUpdate = "http://localhost:56485/api/login/Update/";
        //const string URLTraerPagosUser = "http://localhost:56485/api/login/";
        //const string URLTraerInformacionUser = "http://localhost:56485/api/login/Informacion/";

        const string UrlAuthenticate = URL_BASE+"authenticate/";
        const string UrlRegister = URL_BASE + "Register/";
//        const string URLUpdate = URL_BASE + "Update/";


       

        public async Task<Usuario> Validar(string username, string password)
        {
            try
            {
                LoginRequest loginRequest = new LoginRequest
                {
                    Username = username,
                    Password = password
                };

                HttpClient httpClient = new HttpClient();
                //ASYNC
                //serealizamos la clase para enviarla, se utiliza await para esperar la respuesta asincronica
                var response = await httpClient.PostAsync(UrlAuthenticate,
                    new StringContent(JsonConvert.SerializeObject(loginRequest), Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    //devolvemos la clase deserealizada
                    return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
