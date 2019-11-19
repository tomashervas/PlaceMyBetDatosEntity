using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class ApuestasRepository
    {
        internal List<Apuesta> Recuperar()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuestas.Include(p => p.Mercado).ToList();
            }
            return apuestas;
        }

        internal List<ApuestaDTO> RecuperarDTO()
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Apuestas.Include(p => p.Mercado).ToList();
                apuestas = context.Apuestas.Select(a => ToDTO(a)).ToList();
            }
            return apuestas;
        }
        /*
        internal Apuesta RecuperarApuestaUsuarioDTO(int id)
        {
            Apuesta apuesta = new Apuesta();
            //Apuesta ap = new Apuesta();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Apuestas.Include(a => a.Usuario).ToList();
                apuesta = context.Apuestas.Where(a => a.apuestaID == id).FirstOrDefault();
                //apuesta = context.Apuestas.Select(a => TousuarioDTO(a)).FirstOrDefault();
            }
            return apuesta;
        }*/
        
            /// <summary>
            /// Ejercicio 3
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
        internal ApuestaUsuarioDTO RecuperarApuestaUsuarioDTO(int id)
        {
            ApuestaUsuarioDTO apuesta = new ApuestaUsuarioDTO();
            //Apuesta ap = new Apuesta();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                context.Apuestas.Include(a => a.Usuario).ToList();
                context.Apuestas.Where(a => a.apuestaID == id).FirstOrDefault();
                apuesta = context.Apuestas.Select(a => TousuarioDTO(a)).FirstOrDefault();
            }
            return apuesta;
        }

        public ApuestaUsuarioDTO TousuarioDTO(Apuesta a)
        {
            //string usuarioid = a.Usuario.nombre;

            ApuestaUsuarioDTO apuesta = new ApuestaUsuarioDTO(a.Usuario.nombre, a.cuota);

            return apuesta;
        }

        /// <summary>
        /// Fin Ejercicio 3
        /// </summary>
        /// <param name="a"></param>

        internal void GuardarApuesta(Apuesta a)
        {

            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Apuestas.Add(a);
            context.SaveChanges();
            MercadoRepository repoMercado = new MercadoRepository();
            Mercado mercado = repoMercado.RecuperarMercado(a.mercadoID);

            if (a.tipo.ToLower() == "over")
            {
                mercado.dineroOver = mercado.dineroOver + a.dinero;
                mercado.cuotaOver = Math.Round(Apuesta.CalculoCuota(mercado.dineroOver, mercado.dineroOver, mercado.dineroUnder), 2);
                mercado.cuotaUnder = Math.Round(Apuesta.CalculoCuota(mercado.dineroUnder, mercado.dineroOver, mercado.dineroUnder), 2);
            }
            else
            {
                mercado.dineroUnder = mercado.dineroUnder + a.dinero;
                mercado.cuotaUnder = Math.Round(Apuesta.CalculoCuota(mercado.dineroUnder, mercado.dineroOver, mercado.dineroUnder), 2);
                mercado.cuotaOver = Math.Round(Apuesta.CalculoCuota(mercado.dineroOver, mercado.dineroOver, mercado.dineroUnder), 2);
            }

            repoMercado.ActualizarMercado(mercado);
        }

        public ApuestaDTO ToDTO(Apuesta a)
        {
            int eventoid = a.Mercado.eventoID;

            ApuestaDTO apuesta = new ApuestaDTO(a.usuarioID, eventoid, a.tipo, a.cuota, a.dinero);

            return apuesta;
            
        }

        
    }
}


/*	{
               "mercado": "1.5",
               "tipo": "under",
               "cuota": 1.4,
               "dinero": 40,
               "IDMercado": 1,
               "IDUsuario": 2
           }
           
     
    {         
               "local": "Villareal",
               "visiante": Levante,
               }*/
