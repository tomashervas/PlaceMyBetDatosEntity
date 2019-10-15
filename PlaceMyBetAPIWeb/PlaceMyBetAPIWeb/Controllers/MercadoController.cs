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
        public IEnumerable<MercadoDTO> Get()
        {
            var repoMercado = new MercadoRepository();
            List<MercadoDTO> mercados = repoMercado.RecuperarDTO();
            return mercados;
        }

        // GET: api/Mercado/5
        public Mercado Get(int id)
        {
            var repoMercado = new MercadoRepository();
            Mercado m = repoMercado.RecuperarMercado(id);
            return m;
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
