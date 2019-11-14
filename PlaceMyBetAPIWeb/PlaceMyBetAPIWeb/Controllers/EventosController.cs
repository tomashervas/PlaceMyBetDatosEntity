using PlaceMyBetAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPIWeb.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<EventoDTO> Get()
        {
            var repoEventos = new EventosRepository();
            List<EventoDTO> eventos = repoEventos.RecuperarDTO();
            return eventos;
        }

        // GET: api/Eventos/5
        public Evento Get(int id)
        {
            /*var repoEventos = new EventosRepository();
            Evento e = repoEventos.Recuperar();*/
            return null;
        }

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            var repoEvento = new EventosRepository();
            repoEvento.GuardarEvento(evento);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]Evento evento)
        {
            var repoEvento = new EventosRepository();
            repoEvento.Actualizar(id, evento);
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
            var repoEvento = new EventosRepository();
            repoEvento.Borrar(id);
        }
    
    }
}
