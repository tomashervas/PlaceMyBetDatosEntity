using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Evento
    {
        public Evento(int eventoID, string local, string visitante, DateTime fechaEvento, int horaEvento)
        {
            this.eventoID = eventoID;
            this.local = local;
            this.visitante = visitante;
            this.fechaEvento = fechaEvento;
            this.horaEvento = horaEvento;
        }

        public int eventoID { get; set; }
        public string local { get; set; }
        public string visitante { get; set; }
        public DateTime fechaEvento { get; set; }
        public int horaEvento { get; set; }
    }
}