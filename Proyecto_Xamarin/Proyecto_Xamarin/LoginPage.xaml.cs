using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IdentityModel.Tokens.Jwt;
using Proyecto_Xamarin.Managers;
using Proyecto_Xamarin.Models;

namespace Proyecto_Xamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Dispositivo dispositivo = new Dispositivo();
        public LoginPage()
        {
            InitializeComponent();

            //LogoBanco.Source = ImageSource.FromFile("icon.png");

        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (dispositivo.ValidarConexionInternet())
                {
                    if (ValidarCampos())
                    {

                        var usuarioManager = new UsuarioManager();

                        //traemos el token y se coloca el await y que sea asincrono

                        App.UsuarioActual = await usuarioManager.Validar(txtUsername.Text, txtPassword.Text);

                        //validacion si viene vacio o no
                        if (App.UsuarioActual != null)
                        {
                            //usuario.cadenatoken = UsuarioActual;

                            //obtener datos del token
                            var jwtHandler = new JwtSecurityTokenHandler();
                            JwtSecurityToken URLTOKEN = jwtHandler.ReadJwtToken(App.UsuarioActual.CADENATOKEN);

                            App.UsuarioActual.TOKEN = URLTOKEN;

                            await DisplayAlert("Banco Económico", App.UsuarioActual.USU_NOMBRE + " Bienvenid@ a su Banco en Línea!!", "Ok");

                            //REDIRECCIONA
                            Application.Current.MainPage = new MainPage();


                        }
                        else
                        {
                            lblError.Text = "Credenciales Invalidas";
                            lblError.IsVisible = true;

                        }
                    }
                    else
                    {
                        lblError.Text = "Credenciales Invalidas";
                        lblError.IsVisible = true;
                    }
                }
                else
                {
                    lblError.Text = "Favor conectarse a internet";
                    lblError.IsVisible = true;

                }
            }
            catch (Exception ex)
            {

                lblError.IsVisible = true;
                lblError.Text = ex.ToString();
            }
        }

        public Boolean ValidarCampos()
        {
            Boolean Validar = true;
            try
            {
                if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text) 
                    || (string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtPassword.Text)))
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