using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Conexion()
        {
            string conexionString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=";
            MySqlConnection conexion = new MySqlConnection(conexionString);
            return conexion;
        }

        internal List<Apuesta> Recuperar()
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "select * from apuestas";

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();

                Apuesta a = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (res.Read())
                {
                    //Console.WriteLine("Recuperado " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    a = new Apuesta(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDouble(3), res.GetDouble(4));
                    apuestas.Add(a);
                }
                conexion.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }
    }
}