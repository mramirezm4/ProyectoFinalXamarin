using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Proyecto_Xamarin.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Proyecto_Xamarin.Views
{
    public partial class EssentialsPage : ContentPage
    {
        readonly IList<Dispositivo> dispositivos = new ObservableCollection<Dispositivo>();

        private Dispositivo ObtenerInfoDispositivo()
        {

            Dispositivo dispositivo = new Dispositivo();

            dispositivo.Model = DeviceInfo.Model;
            dispositivo.Manufacturer = DeviceInfo.Manufacturer;
            dispositivo.DeviceName = DeviceInfo.Name;
            dispositivo.Version = DeviceInfo.Version.ToString();

            dispositivo.DeviceType = DeviceInfo.DeviceType.ToString();

            /*dispositivo.Model ="iPhone X 11.2";
            dispositivo.Manufacturer = "Apple";
            dispositivo.DeviceName = "Macbook Pro 15";
            dispositivo.Version = "11.2";
            dispositivo.Platform = "Apple";
            dispositivo.Idiom = "XXX";
            dispositivo.DeviceType = "iPhone";*/

            return dispositivo;
        }
        public EssentialsPage()
        {
            InitializeComponent();
            dispositivos.Add(ObtenerInfoDispositivo());
            BindingContext = dispositivos;
        }
    }
}
