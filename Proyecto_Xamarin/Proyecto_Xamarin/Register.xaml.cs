using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Proyecto_Xamarin.Managers;
using Proyecto_Xamarin.Models;


namespace Proyecto_Xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage
	{
        Dispositivo dispositivo = new Dispositivo();
		public Register ()
		{
			InitializeComponent ();
		}

        async private void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!dispositivo.ValidarConexionInternet())
                {
                    await DisplayAlert("Sin conexión", "Revise su conexión a Internet", "Ok");
                    return;
                }

                if (!ValidarCampos())
                {
                    lblError.Text = "Revise los datos";
                    lblError.IsVisible = true;
                }

                var usuarioManager = new UsuarioManager();
                Usuario usr = preUsuario();

                usr = await usuarioManager.Registrar(usr);

                //validacion si viene vacio o no
                if (usr != null)
                {
                    await DisplayAlert("Banco Económico", "Registro exitoso", "Ok");

                    //REDIRECCIONA
                    Navigation.PopModalAsync();
                }else {
                    lblError.Text = "Credenciales Invalidas";
                    lblError.IsVisible = true;
                }
                
            }
            catch (Exception ex)
            {
                lblError.IsVisible = true;
                lblError.Text = ex.ToString();
            }
        }

        private Usuario preUsuario()
        {
            throw new NotImplementedException();
        }

        private Boolean ValidarCampos()
        {
            Boolean Validar = true;
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text.Trim())
                    || string.IsNullOrEmpty(txtPassword.Text)
                    || string.IsNullOrEmpty(txtPasswordConf.Text)
                    || !string.Equals(txtPassword.Text, txtPasswordConf) )
                {
                    Validar = false;
                }

                return Validar;
            }
            catch (Exception ex)
            {
                lblError.IsVisible = true;
                lblError.Text = ex.ToString();
                return false;
            }



        }
    }
}