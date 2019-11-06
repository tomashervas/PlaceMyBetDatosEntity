using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Cuenta
    {
        public int cuentaID { get; set; }
        public double saldo { get; set; }
        public string banco { get; set; }
        public string tarjeta { get; set; }
        public int usuarioID { get; set; }

        public Usuario Usuario { get; set; }

        public Cuenta(int cuentaID, double saldo, string banco, string tarjeta,int usuarioID)
        {
            this.cuentaID = cuentaID;
            this.saldo = saldo;
            this.banco = banco;
            this.tarjeta = tarjeta;
            this.usuarioID = usuarioID;
        }

        public Cuenta() {
            //Constructor vacio
        }
    }
}