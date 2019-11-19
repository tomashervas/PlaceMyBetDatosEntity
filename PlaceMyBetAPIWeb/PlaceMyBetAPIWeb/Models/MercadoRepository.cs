using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class MercadoRepository
    {
        //Recupera todos los mercados
        internal List<Mercado> Recuperar()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Include(p => p.Evento).ToList();
                //mercados = context.Mercados.ToList();
            }

            return mercados;
        }

        internal List<MercadoDTO> RecuperarDTO()
        {
            List<MercadoDTO> mercados = new List<MercadoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercados.Select(m => ToDTO(m)).ToList();
            }
            return mercados;
            //Recuperar un mercado por id
        }

        internal Mercado RecuperarMercado(int id)
        {
            Mercado mercado = new Mercado();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercado = context.Mercados.Where(m => m.mercadoID == id).FirstOrDefault();
            }

            return mercado;
        }

        internal void GuardarMercado(Mercado mercado) 
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercados.Add(mercado);
            context.SaveChanges();
        }

        internal void ActualizarMercado(Mercado mercado)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Entry(mercado).State = EntityState.Modified;
            context.SaveChanges();
        }

        public MercadoDTO ToDTO(Mercado m)
        {
            return new MercadoDTO(m.mercado, m.cuotaOver, m.cuotaUnder);
        }
        
    }
}