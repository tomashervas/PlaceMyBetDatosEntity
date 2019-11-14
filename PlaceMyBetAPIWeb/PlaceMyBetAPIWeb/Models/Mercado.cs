using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Mercado
    {
        public int mercadoID { get; set; }
        public string mercado { get; set; }
        public double cuotaOver { get; set; }
        public double cuotaUnder { get; set; }
        public double dineroOver { get; set; }
        public double dineroUnder { get; set; }
        public int eventoID { get; set; }

        public Evento Evento { get; set; }
        public List<Apuesta> Apuesta { get; set; }

        public Mercado(int mercadoID, string mercado, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder, int eventoID)
        {
            this.mercadoID = mercadoID;
            this.mercado = mercado;
            this.cuotaOver = cuotaOver;
            this.cuotaUnder = cuotaUnder;
            this.dineroOver = dineroOver;
            this.dineroUnder = dineroUnder;
            this.eventoID = eventoID;
        }

        public Mercado()
        {
            //Constructor vacio
        }
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

/*
  {
  "mercado" : "3.5",
  "cuotaOver" : 1.9,
  "cuotaUnder" : 1.9,
  "dineroOver" : 100,
  "dineroUnder" : 100,
  "eventoID" : 1
}*/
