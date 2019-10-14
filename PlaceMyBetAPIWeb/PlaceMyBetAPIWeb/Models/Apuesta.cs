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

    public class ApuestaDTO
    {
        public ApuestaDTO(string mercado, string tipo, double cuota, double dinero, string email)
        {
            this.mercado = mercado;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
            this.emailUsuario = email;
        }

        public string mercado { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
        public string emailUsuario { get; set; }
    }

    public class ApuestaDTOInsertar
    {
        public ApuestaDTOInsertar(string mercado, string tipo, double cuota, double dinero, int idMercado, int idUsuario)
        {
            
            this.mercado = mercado;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
            this.IDMercado = idMercado;
            this.IDUsuario = idUsuario;

        }

        
        public string mercado { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
        public int IDMercado { get; set; }
        public int IDUsuario { get; set; }
    }
}