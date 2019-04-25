using System;
using Xamarin.Essentials;

namespace Proyecto_Xamarin.Models
{
    public class Dispositivo
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceName { get; set; }
        public string Version { get; set; }
        public string Platform { get; set; }
        public string Idiom { get; set; }
        public string DeviceType { get; set; }


        public string DetalleModel
        {

            get
            {
                return string.Format("Modelo: {0}", Model);
            }
        }

        public string DetalleManufacturer
        {

            get
            {
                return string.Format("Fabricante: {0}", Manufacturer);
            }
        }

        public string DetalleDeviceName
        {

            get
            {
                return string.Format("Nombre: {0}", DeviceName);
            }
        }

        public string DetalleVersion
        {

            get
            {
                return string.Format("Versión: {0}", Version);
            }
        }

        public string DetallePlatform
        {

            get
            {
                return string.Format("Plataforma: {0}", Platform);
            }
        }

        public string DetalleIdiom
        {

            get
            {
                return string.Format("Idiom: {0}", Idiom);
            }
        }

        public string DetalleDeviceType
        {

            get
            {
                return string.Format("Tipo: {0}", DeviceType);
            }
        }

        public bool ValidarConexionInternet()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
                return true;


            return false;
        }

        public Dispositivo()
        {
        }
    }
}
