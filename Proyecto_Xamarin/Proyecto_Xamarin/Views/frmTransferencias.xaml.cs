using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Proyecto_Xamarin.Managers;
using Proyecto_Xamarin.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class frmTransferencias : TabbedPage
    {
        TransferenciaManager tranManager = new TransferenciaManager();
        IEnumerable<Transferencia> trans = new ObservableCollection<Transferencia>();
        public frmTransferencias()
        {
            InitializeComponent();

            LoadData();
        }



        async private void BtnTransferirFondos_Clicked(object sender, EventArgs e)
        {
            try
            {

                Transferencia nueva_trans = new Transferencia
                {
                    TRA_CODIGO = Convert.ToInt32(10001),
                    TRA_CUENTA_ORIGEN = Convert.ToInt32(txtCuentaOrigen.Text),
                    TRA_CUENTA_DESTINO = Convert.ToInt32(txtCuentaDestino.Text),
                    TRA_DESCRIPCION = txtDescripcion.Text,
                    TRA_ESTADO = "A",
                    TRA_FECHA = Convert.ToDateTime("2019-04-27"),
                    TRA_MONTO = Convert.ToDecimal(txtMonto.Text),

                };

                TransferenciaManager registrarTrans = new TransferenciaManager();
                Transferencia transRegistrada = await registrarTrans.Ingresar(nueva_trans);
                LoadData();

            }

            catch (Exception ex)
            {

            }
        }

        async private void LoadData()
        {


            trans = await tranManager.GetTransferencias();
            ListViewTransferencias.ItemsSource = trans.ToList();
        }

        private void BtnTranRegresar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }

        private void Regresar_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage();
        }
    }
}
