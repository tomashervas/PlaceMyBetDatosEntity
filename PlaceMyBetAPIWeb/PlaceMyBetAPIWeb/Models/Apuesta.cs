using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Apuesta
    {
        public Apuesta(int apuestaID, string mercado, string tipo, double cuota, double dinero)
        {
            this.apuestaID = apuestaID;
            this.mercado = mercado;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
        }

        public int apuestaID { get; set; }
        public string mercado { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
    }
}