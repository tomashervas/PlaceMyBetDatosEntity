using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class EventosRepository
    {

        internal List<Evento> Recuperar()
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }
            return eventos;
        }

        internal void GuardarEvento(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(evento);
            context.SaveChanges();
        }

        public EventoDTO ToDTO(Evento e)
        {
            return new EventoDTO(e.local, e.visitante);
        }

        internal List<EventoDTO> RecuperarDTO()
        {
            List<EventoDTO> eventos = new List<EventoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.Select(p => ToDTO(p)).ToList();
            }
            return eventos;
        }
    }
    
}