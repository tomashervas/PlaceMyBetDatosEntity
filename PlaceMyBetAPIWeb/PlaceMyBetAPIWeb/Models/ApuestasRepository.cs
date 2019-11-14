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

        internal Apuesta RecuperarApuesta(int id)
        {
            Apuesta apuesta = new Apuesta();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuesta = context.Apuestas.Where(a => a.apuestaID == id).FirstOrDefault();
            }

            return apuesta;
        }

        internal void GuardarApuesta(Apuesta a)
        {
            /*CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;*/

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
        /*
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
            return null;
        }*/
        /*
        internal List<ApuestaDTO> RecuperarXMercadoDTO(int idMercado)
        {
            /*MySqlConnection conexion = Conexion();
            MySqlCommand comando = conexion.CreateCommand();
            comando.CommandText = "SELECT mercado, tipo, cuota, dinero, email FROM apuestas, usuarios WHERE apuestas.IDUsuario = usuarios.ID and IDMercado=@idMercado";
            comando.Parameters.AddWithValue("@idMercado", idMercado);
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
            }*/
        // return null;
        // }

        //internal List<ApuestaXEmailDTO> RecuperarXEmail(string email)
        //{
        /*MySqlConnection conexion = Conexion();
        MySqlCommand comando = conexion.CreateCommand();
        comando.CommandText = "SELECT evento.ID, evento.local, evento.visitante, apuestas.mercado, apuestas.tipo, apuestas.cuota, apuestas.dinero FROM apuestas INNER JOIN mercado ON apuestas.IDMercado = mercado.ID INNER JOIN evento on evento.ID=mercado.IDEvento INNER JOIN usuarios on apuestas.IDUsuario = usuarios.ID AND usuarios.email=@email;";
        comando.Parameters.AddWithValue("@email", email);
        try
        {
            conexion.Open();
            MySqlDataReader res = comando.ExecuteReader();

            ApuestaXEmailDTO a = null;
            List<ApuestaXEmailDTO> apuestas = new List<ApuestaXEmailDTO>();
            while (res.Read())
            {
                a = new ApuestaXEmailDTO(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetString(3), res.GetString(4), res.GetDouble(5), res.GetDouble(6));
                apuestas.Add(a);
            }
            conexion.Close();
            return apuestas;
        }
        catch (MySqlException e)
        {
            Console.WriteLine("Se ha producido un error de conexion");
            return null;
        }*/
        // return null;
        //}





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
