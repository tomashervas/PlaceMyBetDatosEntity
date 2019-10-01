using PlaceMyBetAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPIWeb.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<Mercado> Get()
        {
            var repoMercado = new MercadoRepository();
            List<Mercado> mercados = repoMercado.Recuperar();
            return mercados;
        }

        // GET: api/Mercado/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
