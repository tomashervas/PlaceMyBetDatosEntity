﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Apuesta
    {
        public int apuestaID { get; set; }
        public string mercado { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
        public int mercadoID { get; set; }
        public int usuarioID { get; set; }

        public Mercado Mercado { get; set; }
        public Usuario Usuario { get; set; }            


        public Apuesta(int apuestaID, string mercado, string tipo, double cuota, double dinero,int mercadoID,int usuarioID)
        {
            this.apuestaID = apuestaID;
            this.mercado = mercado;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
            this.mercadoID = mercadoID;
            this.usuarioID = usuarioID;
        }

        public Apuesta()
        {
            //Constructor vacio
        }

        
        public static double CalculoCuota (double dinero, double dineroOver, double dineroUnder)
        {
            double cuota;
            double total = dineroOver + dineroUnder;
            double probabilidad = dinero / total;
            cuota = (1 / probabilidad) * 0.95;

            return cuota;
        }
    }
    
    public class ApuestaDTO
    {
        public ApuestaDTO(int usuarioID, int eventoID, string tipo, double cuota, double dinero)
        {
            this.usuarioID = usuarioID;
            this.eventoID = eventoID;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
        }

        public int usuarioID { get; set; }
        public int eventoID { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
    }


    /// <summary>
    /// Ejercicio 3
    /// </summary>
    public class ApuestaUsuarioDTO
    {
        public ApuestaUsuarioDTO()
        {
        }

        public ApuestaUsuarioDTO(string nombre, double cuota)
        {
            Nombre = nombre;
            Cuota = cuota;
        }

        public string Nombre { get; set; }
        public double Cuota { get; set; }


    }

    /*
    public class ApuestaDTOInsertar
    {
        public ApuestaDTOInsertar(string mercado, string tipo, double cuota, double dinero, int idMercado, int idUsuario)
        {
            
            this.mercado = mercado;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
            this.IDMercado = idMercado;
            this.IDUsuario = idUsuario;

        }

        
        public string mercado { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
        public int IDMercado { get; set; }
        public int IDUsuario { get; set; }
    }

    public class ApuestaXEmailDTO
    {
        public ApuestaXEmailDTO(int idEvento, string local, string visitante, string mercado, string tipo, double cuota, double dinero)
        {
            this.idEvento = idEvento;
            this.local = local;
            this.visitante = visitante;
            this.mercado = mercado;
            this.tipo = tipo;
            this.cuota = cuota;
            this.dinero = dinero;
        }

        public int idEvento { get; set; }
        public string local { get; set; }
        public string visitante { get; set; }
        public string mercado { get; set; }
        public string tipo { get; set; }
        public double cuota { get; set; }
        public double dinero { get; set; }
    }*/
}