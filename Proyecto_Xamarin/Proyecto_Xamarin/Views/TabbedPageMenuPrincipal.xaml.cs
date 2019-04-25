using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_Xamarin.Managers;
using Proyecto_Xamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPageMenuPrincipal : TabbedPage
    {
        Dispositivo Dispositivo = new Dispositivo();
        CuentaManager eCuentaManager = new CuentaManager();

        public TabbedPageMenuPrincipal ()
        {
            InitializeComponent();
            CargarListaCuentas();

        }


        async void CargarListaCuentas()
        {
            if (Dispositivo.ValidarConexionInternet())
            {
                IEnumerable<Cuenta> cuentas = await
                eCuentaManager.GetCuentas(App.UsuarioActual.USU_CODIGO.ToString());

                CuentasListDelete.ItemsSource = cuentas;
                CuentasListDelete.BindingContext = cuentas;
            }
            else
            {
                await DisplayAlert("Banco Económico", "No existe conexión a Internet", "Ok");

            }
        }


        async private void AgregarCuenta_Clicked(object sender, EventArgs e)
        {
            if (Dispositivo.ValidarConexionInternet())
            {

                if (ValidarCampos())
                {
                    CuentaManager eCuentaManager = new CuentaManager();
                    Cuenta eCuentaIngresada = new Cuenta();
                    Cuenta eCuenta = new Cuenta()
                    {
                        CUE_DESCRIPCION = txtDescripcion.Text,
                        CUE_MONEDA = txtMoneda.Text,
                        CUE_SALDO = Convert.ToDecimal(txtSaldo.Text),
                        CUE_ESTADO = "A",
                        USU_CODIGO = App.UsuarioActual.USU_CODIGO
                    };

                    eCuentaIngresada = await eCuentaManager.Ingresar(eCuenta);

                    if (eCuentaIngresada != null)
                    {
                        txtSaldo.Text = string.Empty;
                        txtMoneda.Text = string.Empty;
                        txtDescripcion.Text = string.Empty;
                        await DisplayAlert("Información", "Cuenta Registrada", "Ok");
                    }
                    else
                        await DisplayAlert("Alerta", "La cuenta no pudo ser registrada, favor validar", "Ok");

                }
                else
                {
                    await DisplayAlert("Alerta", "Favor Validar Datos", "Ok");

                }
            }
            else
            {
                await DisplayAlert("Banco Económico", "No existe conexión a Internet", "Ok");

            }
       }
    

        private void Regresar_Clicked(object sender, EventArgs e)
        {
            txtSaldo.Text = string.Empty;
            txtMoneda.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtDescripcionMOD.Text = string.Empty;
            txtEstadoMOD.Text = string.Empty;
            txtMonedaMOD.Text = string.Empty;

            Application.Current.MainPage = new MainPage();

        }


         public Boolean ValidarCampos()
        {
            Boolean Correcto = true;
            try
            {

                if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrEmpty(txtMoneda.Text) || string.IsNullOrEmpty(txtSaldo.Text))
                {

                    Correcto = false;

                }

                return Correcto;
            }
            catch (Exception ex)
            {

                return false;
            }

        }

       async private void ActualizarCuenta_Clicked(object sender, EventArgs e)
        {
            if (Dispositivo.ValidarConexionInternet())
            {

                if (ValidarCamposEditar())
                {
                    CuentaManager eCuentaManager = new CuentaManager();
                    Cuenta eCuentaIngresada = new Cuenta();
                    Cuenta eCuenta = new Cuenta()
                    {
                        CUE_CODIGO = int.Parse(txtCodigo.Text),
                        CUE_DESCRIPCION = txtDescripcionMOD.Text,
                        CUE_MONEDA = txtMonedaMOD.Text,
                        CUE_ESTADO = txtEstadoMOD.Text,
                        USU_CODIGO = App.UsuarioActual.USU_CODIGO
                    };

                    eCuentaIngresada = await eCuentaManager.Actualizar(eCuenta);

                    if (eCuentaIngresada != null)
                    {
                        txtMonedaMOD.Text = string.Empty;
                        txtDescripcionMOD.Text = string.Empty;
                        txtEstadoMOD.Text = string.Empty;
                        txtCodigo.Text = string.Empty;

                        await DisplayAlert("Información", "Cuenta Actualizada Correctamente", "Ok");
                    }
                    else
                        await DisplayAlert("Alerta", "La cuenta no pudo ser actualizada, favor validar", "Ok");

                }
                else
                {


                }
            }
            else
            {
                await DisplayAlert("Banco Económico", "No existe conexión a Internet", "Ok");

            }
        }


        public Boolean ValidarCamposEditar()
        {
            Boolean Correcto = true;
            try
            {

                if (string.IsNullOrEmpty(txtDescripcionMOD.Text) || string.IsNullOrEmpty(txtMonedaMOD.Text) || string.IsNullOrEmpty(txtEstadoMOD.Text))
                {

                    Correcto = false;

                }

                return Correcto;
            }
            catch (Exception ex)
            {

                return false;
            }

        }
        async private void ElimiarCuenta_Clicked(object sender, EventArgs e)
        {

            if (Dispositivo.ValidarConexionInternet())
            {
                string id = ((Cuenta)CuentasListDelete.SelectedItem).CUE_CODIGO.ToString();

                string codigoCuentaEliminada = await eCuentaManager.Eliminar(id);

                if (string.IsNullOrEmpty(codigoCuentaEliminada))
                    await DisplayAlert("Información", "No se pudo eliminar la cuenta", "Ok");
                else
                {
                    await DisplayAlert("Alerta", "La cuenta eliminada correctamente", "Ok");
                    CargarListaCuentas();
                }
            }

        }
    }
}