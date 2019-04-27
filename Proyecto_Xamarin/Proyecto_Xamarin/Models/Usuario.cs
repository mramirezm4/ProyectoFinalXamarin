using System;
using Microsoft.IdentityModel.Tokens;

namespace Proyecto_Xamarin.Models
{
    public class Usuario
    {
        public int USU_CODIGO { get; set; }
        public string USU_IDENTIFICACION { get; set; }
        public string USU_NOMBRE { get; set; }
        public string USU_USERNAME { get; set; }
        public string USU_PASSWORD { get; set; }
        public string USU_EMAIL { get; set; }
        public DateTime USU_FEC_NAC { get; set; }
        public string USU_ESTADO { get; set; }


        public SecurityToken Token { get; set; }
        public string TOKEN { get; set; }


        public Usuario()
        {
        }
    }
}
