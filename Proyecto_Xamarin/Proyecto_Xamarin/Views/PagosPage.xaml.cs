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
                    
        }

        async private void LoadData()
        {
            cuentas = await cuentaManager.GetCuentas(App.UsuarioActual.USU_CODIGO.ToString());
            servicios = await servicioManager.GetServicios();
            pagos = await pagoManager.GetPagos();

            pkrCuentas.ItemsSource = cuentas.ToList();
            pkrCuentas.BindingContext = cuentas.ToList();

            pkrServicios.ItemsSource = servicios.ToList();
            PagosListView.ItemsSource = pagos.ToList();
            PagosListView.BindingContext = pagos;
            
        }



        void btnRegresar_Clicked(object sender, System.EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
            //Navigation.PopModalAsync();
        }

        async private void btnPagar_Clicked(object sender, EventArgs e)
        {
            if (!RevisarCampos())
            {
                await DisplayAlert("Atención","Revise los campos","OK");
                return;
            }

            Pago npago = await pagoManager.Ingresar(prepPago()); 
            if(npago != null)
            {
                LoadData();
                txtMonto.Text = "";
                await DisplayAlert("Felicidades", "Su Pago se registró con exito", "OK");
            }
            else
            {
                await DisplayAlert("Error", "No fue posible registrar el pago", "OK");
            }

        }



        private Pago prepPago()
        {
            Pago p = new Pago()
            {
                CUE_CODIGO = ((Cuenta)pkrCuentas.SelectedItem).CUE_CODIGO,
                PAG_FECHA = DateTime.Now,
                PAG_MONTO = Decimal.Parse(txtMonto.Text),
                SER_CODIGO = ((Servicio)pkrServicios.SelectedItem).SER_CODIGO
            };

            return p;
        }

        private Boolean RevisarCampos()
        {
            Boolean OK = true;
            Decimal monto;

            if (pkrServicios.SelectedIndex <0 
                || pkrCuentas.SelectedIndex < 0
                || string.IsNullOrEmpty(txtMonto.Text)
                || !Decimal.TryParse(txtMonto.Text, out monto)
                || ((Cuenta)pkrCuentas.SelectedItem).CUE_SALDO <monto )
            {
                OK = false;
            }


            return OK;
        }
       
    }
}
