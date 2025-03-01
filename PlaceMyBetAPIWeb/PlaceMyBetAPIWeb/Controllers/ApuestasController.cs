﻿using PlaceMyBetAPIWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBetAPIWeb.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            var repoApuestas = new ApuestasRepository();
            List<ApuestaDTO> apuestas = repoApuestas.RecuperarDTO();
            return apuestas;
        }
        /*
        // Get: api/apuestas?idMercado=id
        [Authorize(Roles ="admin")]
        public IEnumerable<Apuesta> GetXMercado(int idMercado)
        {
            var repoApuestas = new ApuestasRepository();
            List<Apuesta> apuestas = repoApuestas.RecuperarXMercadoDTO(idMercado);
            return apuestas;
        }*/
        /*
        //GET: api/apuestas?email=email
        public IEnumerable<ApuestaXEmailDTO> GetXEmail(string email)
        {
            var repoApuestas = new ApuestasRepository();
            List<ApuestaXEmailDTO> apuestas = repoApuestas.RecuperarXEmail(email);
            return apuestas;
        }*/
        
        // GET: api/Apuestas/5


        /// <summary>
        /// Ejercicio 3
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApuestaUsuarioDTO Get(int id)
        {
            var repoApuesta = new ApuestasRepository();
            ApuestaUsuarioDTO a = repoApuesta.RecuperarApuestaUsuarioDTO(id);
            return a;
        }
        /*
        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            var repoApuesta = new ApuestasRepository();
            Apuesta a = repoApuesta.RecuperarApuestaUsuarioDTO(id);
            return a;
        }*/

        //POST: api/Apuestas
        //[Authorize]
        public void Post([FromBody]Apuesta apuesta)
        {
            var repoApuestas = new ApuestasRepository();
            repoApuestas.GuardarApuesta(apuesta);
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
