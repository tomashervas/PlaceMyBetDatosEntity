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
        public IEnumerable<Evento> Get()
        {
            var repoEventos = new EventosRepository();
            List<Evento> eventos = repoEventos.Recuperar();
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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
