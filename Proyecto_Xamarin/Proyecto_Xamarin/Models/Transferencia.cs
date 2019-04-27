using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_Xamarin.Models
{
    class Transferencia
    {

        public int TRA_CODIGO { set; get; }
        public int TRA_CUENTA_ORIGEN { set; get; }
        public int TRA_CUENTA_DESTINO { set; get; }
        public string TRA_DESCRIPCION { set; get; }
        public string TRA_ESTADO { set; get; }
        public DateTime TRA_FECHA { set; get; }
        public decimal TRA_MONTO { set; get; }

        public string TRA_CUENTA_ORIGEN_label
        {
            get
            {
                return string.Format("Origen: {0} - {1} - {2}",TRA_CODIGO,
                    TRA_CUENTA_ORIGEN, TRA_DESCRIPCION);
            }
        }

        public string TRA_CUENTA_DESTINO_label
        {
            get
            {
                return string.Format("Destino: {0} - {1} - {2}", TRA_CUENTA_DESTINO,
                    TRA_MONTO, TRA_FECHA.ToString("dd/MM/yyyy"));
            }
        }

        public Transferencia()
        {
        }
    }
}
