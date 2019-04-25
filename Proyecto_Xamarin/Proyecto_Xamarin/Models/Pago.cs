using System;
namespace Proyecto_Xamarin.Models
{
    public class Pago
    {
        public int PAG_CODIGO { get; set; }
        public int SER_CODIGO { get; set; }
        public int CUE_CODIGO { get; set; }
        public DateTime PAG_FECHA { get; set; }
        public decimal PAG_MONTO { get; set; }

        public string PAG_DESCRIPCION
        {

            get
            {

                return string.Format("{0}-{1}-{2:N2}", PAG_CODIGO, 
                PAG_FECHA.ToString("dd/MM/yyyy"),
                    PAG_MONTO.ToString());
            }

        }
        public Pago()
        {
        }
    }
}
