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
        //const string UrlRegister = "http://localhost:56485/api/login/Register/";
        //const string URLUpdate = "http://localhost:56485/api/login/Update/";
        //const string URLTraerPagosUser = "http://localhost:56485/api/login/";
        //const string URLTraerInformacionUser = "http://localhost:56485/api/login/Informacion/";

        const string UrlAuthenticate = "http://192.168.0.7:45455/api/login/authenticate/";
        const string UrlRegister = "http://192.168.0.7:45455/api/login/Register/";
        const string URLUpdate = "http://192.168.0.7:45455/api/login/Update/";
        const string URLTraerPagosUser = "http://192.168.0.7:45455/api/login/";
        const string URLTraerInformacionUser = "http://192.168.0.7:45455/api/login/Informacion/";


       

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

        public async Task<Usuario> Registrar(Usuario usuario)
        {

            HttpClient client = new HttpClient();
            var response = await client.PostAsync(UrlRegister,
                new StringContent(JsonConvert.SerializeObject(usuario),
                Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
        }

        public UsuarioManager()
        {
        }
    }
}
