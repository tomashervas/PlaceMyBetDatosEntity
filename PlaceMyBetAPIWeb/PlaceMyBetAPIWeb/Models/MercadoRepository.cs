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

        /*internal List<MercadoDTO> RecuperarDTO()
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "select * from mercado";

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    m = new MercadoDTO(res.GetString(1), res.GetDouble(2), res.GetDouble(3));
                    mercados.Add(m);
                }
                conexion.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexion");
                return null;
            }
            return null;
        }*/

        /*internal List<MercadoDTO> RecuperarXEventoDTO(int idEvento)
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "select * from mercado where IDEvento = @id";
            comando.Parameters.AddWithValue("@id", idEvento);

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();

                MercadoDTO m = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    m = new MercadoDTO(res.GetString(1), res.GetDouble(2), res.GetDouble(3));
                    mercados.Add(m);
                }
                conexion.Close();
                return mercados;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexion");
                return null;
            }
            return null;
        }*/

        /*internal Mercado RecuperarMercado(int id)
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "select * from mercado where mercado.ID = @id";
            comando.Parameters.AddWithValue("@id", id);

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();
                Mercado mercado = null;
                if (res.Read())
                {
                    mercado = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5));
                }
                conexion.Close();
                return mercado;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexion");
                return null;
            }
            return null;
        }*/


    }
}