using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Proyecto_Xamarin.Models;
using Proyecto_Xamarin.Managers;

namespace Proyecto_Xamarin
{
    public partial class MainPage : ContentPage
    {
        CuentaManager eCuentaManager = new CuentaManager();
        Dispositivo dispositivo = new Dispositivo();

        public MainPage()
        {
            InitializeComponent();
            CargarListaCuentas();
        }

        async void CargarListaCuentas()
        {
            if (dispositivo.ValidarConexionInternet())
            {
                IEnumerable<Cuenta> cuentas = await 
                    eCuentaManager.GetCuentas(App.UsuarioActual.USU_CODIGO.ToString());

                CuentasList.ItemsSource = cuentas;
                CuentasList.BindingContext = cuentas;
            }
            else
            {
                await DisplayAlert("Banco Económico", "No existe conexión a Internet", "Ok");

            }
        }

        private void AdministrarCuenta_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Views.TabbedPageMenuPrincipal();
            Navigation.PushModalAsync(new Views.TabbedPageMenuPrincipal());
            CargarListaCuentas();
        }

        private void AdministrarPagos_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new Views.PagosPage();
            Navigation.PushModalAsync(new Views.PagosPage());
            CargarListaCuentas();
        }

        private void BtnAdministrarTransferencias_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Views.frmTransferencias();
        }

      async  private void CerrarSesion_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Banco Económico", App.UsuarioActual.USU_NOMBRE + " Le esperamos pronto.", "Ok");

            Application.Current.MainPage = new LoginPage();

        }
    }
}
