using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Proyecto_Xamarin.Managers;
using Proyecto_Xamarin.Models;

using Xamarin.Forms;

namespace Proyecto_Xamarin.Views
{
    public partial class PagosPage : ContentPage
    {
        ServicioManager servicioManager = new ServicioManager();
        CuentaManager cuentaManager = new CuentaManager();
        PagoManager pagoManager = new PagoManager();

        IEnumerable<Cuenta> cuentas = new ObservableCollection<Cuenta>();
        IEnumerable<Servicio> servicios = new ObservableCollection<Servicio>();
        IEnumerable<Pago> pagos = new ObservableCollection<Pago>();

        public PagosPage()
        {
            InitializeComponent();
            LoadData();

        /* BINDING EN ENTRY           
            Usuario usuario = new Usuario();
            usuario.USU_NOMBRE = "Pate Centeno";
            txtBienvenida.BindingContext = usuario; */
        }

        async private void LoadData()
        {
            cuentas = await cuentaManager.GetCuentas(App.UsuarioActual.USU_CODIGO.ToString());
            servicios = await servicioManager.GetServicios();
            pagos = await pagoManager.GetPagos();

            pkrCuentas.ItemsSource = cuentas.ToList();
            pkrServicios.ItemsSource = servicios.ToList();
            PagosListView.ItemsSource = pagos.ToList();
        }



        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
