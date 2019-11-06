using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class EventosRepository
    {
        /*private MySqlConnection Conexion()
        {
            string conexionString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=";
            MySqlConnection conexion = new MySqlConnection(conexionString);
            return conexion;
        }*/

       internal List<Evento> Recuperar()
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Eventos.ToList();
            }
            return eventos;
            /*
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "select * from evento";

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();

                Evento e = null;
                List<Evento> eventos = new List<Evento>();
                while (res.Read())
                {
                    //Console.WriteLine("Recuperado " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(e);
                }
                conexion.Close();
                return eventos;
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexion");
                return null;
            }*/

        }

        internal void GuardarEvento(Evento evento)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Eventos.Add(evento);
            context.SaveChanges();
        }

        /*internal List<EventoDTO> RecuperarDTO()
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "select * from evento";

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();

                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (res.Read())
                {
                    e = new EventoDTO(res.GetString(1), res.GetString(2));
                    eventos.Add(e);
                }
                conexion.Close();
                return eventos;
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