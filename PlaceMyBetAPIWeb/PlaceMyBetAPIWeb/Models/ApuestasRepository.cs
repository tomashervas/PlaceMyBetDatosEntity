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

        internal List<ApuestaDTO> RecuperarDTO()
        {
            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT mercado, tipo, cuota, dinero, email FROM apuestas, usuarios WHERE apuestas.IDUsuario = usuarios.ID";

            try
            {
                conexion.Open();
                MySqlDataReader res = comando.ExecuteReader();

                ApuestaDTO a = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (res.Read())
                {
                    a = new ApuestaDTO(res.GetString(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3), res.GetString(4));
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

        internal void GuardarApuesta(ApuestaDTOInsertar a)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "INSERT INTO `apuestas` (`mercado`, `tipo`, `cuota`, `dinero`, `IDMercado`, `IDUsuario`) VALUES ('" + a.mercado + "', '"+a.tipo+"', '"+a.cuota+"', '"+a.dinero+"', '"+a.IDMercado+"', '"+a.IDUsuario+"');";
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch(MySqlException e)
            {
                Console.WriteLine("Se ha producido un error de conexión");
            }

            MercadoRepository repoMercado = new MercadoRepository();
            Mercado mercado = repoMercado.RecuperarMercado(a.IDMercado);
            //Console.WriteLine(mercado.mercadoID + " " + mercado.cuotaOver + " " + mercado.dineroOver);
            if(a.tipo.ToLower() == "over")
            {
                mercado.dineroOver = mercado.dineroOver + a.dinero;
                mercado.cuotaOver = Math.Round(Apuesta.CalculoCuota(mercado.dineroOver, mercado.dineroOver, mercado.dineroUnder),2);
                mercado.cuotaUnder = Math.Round(Apuesta.CalculoCuota(mercado.dineroUnder, mercado.dineroOver, mercado.dineroUnder),2);
            }
            else
            {
                mercado.dineroUnder = mercado.dineroUnder + a.dinero;
                mercado.cuotaUnder = Math.Round(Apuesta.CalculoCuota(mercado.dineroUnder, mercado.dineroOver, mercado.dineroUnder),2);
                mercado.cuotaOver = Math.Round(Apuesta.CalculoCuota(mercado.dineroOver, mercado.dineroOver, mercado.dineroUnder),2);
            }

            repoMercado.ActualizarMercado(mercado);

        }

        /*	{
                "mercado": "1.5",
                "tipo": "under",
                "cuota": 1.4,
                "dinero": 40,
                "IDMercado": 1,
                "IDUsuario": 2
            }*/

    }
}
 
 