using Microsoft.EntityFrameworkCore;
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

        internal void Actualizar(int id, Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            var eventoActualizar = context.Eventos.FirstOrDefault(ev => ev.eventoID == id);
            eventoActualizar.local = evento.local;
            eventoActualizar.visitante = evento.visitante;
            context.SaveChanges();
            
        }

        internal void Borrar(int id)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            var eventoEliminar = context.Eventos.FirstOrDefault(ev => ev.eventoID == id);
            context.Eventos.Remove(eventoEliminar);
            context.SaveChanges();
            
        }

    }
    
}