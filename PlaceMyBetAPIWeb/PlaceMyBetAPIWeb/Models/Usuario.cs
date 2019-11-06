using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class Usuario
    {
        public int usuarioID { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public int edad { get; set; }
        public double saldo { get; set; }

        public Cuenta Cuenta { get; set; }

        public Usuario(int usuarioID, string nombre, string apellidos, string email, int edad, double saldo)
        {
            this.usuarioID = usuarioID;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.edad = edad;
            this.saldo = saldo;
        }

        public Usuario()
        {
            //Constructor vacio
        }
    }
}