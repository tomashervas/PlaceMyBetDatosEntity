using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class EventosRepository
    {
        private MySqlConnection Conexion()
        {
            string conexionString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=";
            MySqlConnection conexion = new MySqlConnection(conexionString);
            return conexion;
        }

       internal List<Evento> Recuperar()
        {
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
                    Console.WriteLine("Recuperado " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDateTime(3), 20);
                    eventos.Add(e);
                }
                conexion.Close();
                return eventos;
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexion");
                return null;
            }
            
            /*
            DateTime date1 = new DateTime(2020, 6, 1, 7, 47, 0);
            Evento even1 = new Evento(1, "valencia", "madrid", date1.Date, date1.Hour);
            return even1;*/
        }
    }
}