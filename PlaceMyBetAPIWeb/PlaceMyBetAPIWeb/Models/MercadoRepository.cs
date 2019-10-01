using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class MercadoRepository
    {
        private MySqlConnection Conexion()
        {
            string conexionString = "Server=localhost;Port=3306;Database=placemybet;Uid=root;password=";
            MySqlConnection conexion = new MySqlConnection(conexionString);
            return conexion;
        }

        internal List<Mercado> Recuperar()
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "select * from mercado";

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();

                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    //Console.WriteLine("Recuperado " + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    m = new Mercado(res.GetInt32(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5));
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
        }
    }
}