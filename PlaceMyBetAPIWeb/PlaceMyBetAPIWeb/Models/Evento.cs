using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Evento
    {
        public Evento(int eventoID, string local, string visitante, DateTime fechaHoraEvento)
        {
            this.eventoID = eventoID;
            this.local = local;
            this.visitante = visitante;
            this.fechaEvento = fechaHoraEvento.ToShortDateString();
            this.horaEvento = fechaHoraEvento.ToShortTimeString();
        }

        public int eventoID { get; set; }
        public string local { get; set; }
        public string visitante { get; set; }
        public string fechaEvento { get; set; }
        public string horaEvento { get; set; }
    }

    //Devuelve sólo los nombres de los equipos
    public class EventoDTO
    {
        public EventoDTO(string local, string visitante)
        {
            this.local = local;
            this.visitante = visitante;
        }

        public string local { get; set; }
        public string visitante { get; set; }
    }
}