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

        internal List<MercadoDTO> RecuperarDTO()
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
        }

        internal Mercado RecuperarMercado(int id)
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
        }

        internal void ActualizarMercado(Mercado mercado)
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            
            comando.CommandText = "UPDATE `mercado` SET `cuotaOver` = '"+ mercado.cuotaOver +"', cuotaUnder = '" + mercado.cuotaUnder + "', `dineroOver` = '" + mercado.dineroOver + "', dineroUnder = '"+ mercado.dineroUnder +"' WHERE mercado.ID = " + mercado.mercadoID +";";
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexión");
            }
        }

        //UPDATE `mercado` SET `cuotaOver` = '1.41', `dineroOver` = '115' WHERE `mercado`.`ID` = 1;
    }
}