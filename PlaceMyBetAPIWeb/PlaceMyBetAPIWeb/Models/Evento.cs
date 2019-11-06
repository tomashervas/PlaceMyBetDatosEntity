using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Evento
    {
        public int eventoID { get; set; }
        public string local { get; set; }
        public string visitante { get; set; }
        public DateTime fechaHoraEvento { get; set; }
        public List<Mercado> Mercados  { get; set; }

        public Evento(int eventoID, string local, string visitante, DateTime fechaHoraEvento)
        {
            this.eventoID = eventoID;
            this.local = local;
            this.visitante = visitante;
            this.fechaHoraEvento = fechaHoraEvento;
        }

        public Evento()
        {

        }

        
    }
    /*
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
    }*/
}