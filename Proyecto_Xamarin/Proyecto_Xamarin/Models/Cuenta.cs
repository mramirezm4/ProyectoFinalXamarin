using System;
namespace Proyecto_Xamarin.Models
{
    public class Cuenta
    {
        public int CUE_CODIGO { get; set; }
        public int USU_CODIGO { get; set; }
        public string CUE_DESCRIPCION { get; set; }
        public string CUE_MONEDA { get; set; }
        public decimal CUE_SALDO { get; set; }
        public string CUE_ESTADO { get; set; }

        public string CUE_DESCRIPCION_label
        {

            get
            {

                return string.Format("Cuenta: {0}-{1}", CUE_CODIGO, CUE_DESCRIPCION);
            }

        }

        public string CUE_SALDO_label
        {

            get
            {

                return string.Format("Saldo: {0} {1:N2}", 
                    (CUE_MONEDA.Trim().Equals("DOL") ? "$" :
                    (CUE_MONEDA.Trim().Equals("COL") ? "¢" : "€")), CUE_SALDO);
            }

        }

      

       
    }
}
