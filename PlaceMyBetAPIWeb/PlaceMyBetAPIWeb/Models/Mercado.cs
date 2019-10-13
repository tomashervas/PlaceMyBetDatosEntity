using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Mercado
    {
        public Mercado(int mercadoID, string mercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            this.mercadoID = mercadoID;
            this.mercado = mercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
        }

        public int mercadoID { get; set; }
        public string mercado { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
    }

    public class MercadoDTO
    {
        public MercadoDTO(string mercado, double cuotaOver, double cuotaUnder)
        {
            this.mercado = mercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
        }

        public string mercado { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
    }
}