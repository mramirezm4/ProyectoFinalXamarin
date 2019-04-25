using System;
namespace Proyecto_Xamarin.Models
{
    public class Servicio
    {
        public string SER_CODIGO { get; set; }
        public string SER_DESCRIPCION { get; set; }
        public string SER_ESTADO { get; set; }

        public string SER_DESCRIPCION_label
        {

            get
            {

                return string.Format("{0}-{1}", SER_CODIGO, SER_DESCRIPCION);
            }

        }

        public Servicio()
        {
        }
    }
}
