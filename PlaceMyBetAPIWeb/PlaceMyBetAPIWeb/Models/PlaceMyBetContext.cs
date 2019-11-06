using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPIWeb.Models
{
    public class PlaceMyBetContext : DbContext
    {
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Mercado> Mercados { get; set; }
        public DbSet<Apuesta> Apuestas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cuenta> Cuentas { get; set; }

        public PlaceMyBetContext()
        {
            //Constructor vacio
        }

        public PlaceMyBetContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=placemybetentity;Uid=root;Pwd=''; SslMode = none");

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().HasData(new Evento(1, "Valencia", "Madrid", DateTime.Now));
            modelBuilder.Entity<Evento>().HasData(new Evento(2, "Barcelona", "Betis", DateTime.Now));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(1, "Pepe", "Garcia", "pepegarcia@gmail.com", 34, 200));
            modelBuilder.Entity<Usuario>().HasData(new Usuario(2, "Rosa", "Sanchez", "rosasanchez@gmail.com", 25, 300));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(1, 200, "Bankia", "2222222222222222", 1));
            modelBuilder.Entity<Cuenta>().HasData(new Cuenta(2, 200, "Savadell", "333333333333333", 2));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(1, "1.5", 1.9,1.9,100,100,1));
            modelBuilder.Entity<Mercado>().HasData(new Mercado(2, "2.5",1.9, 1.9, 100, 100, 1));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(1, "1.5", "under", 1.9, 20, 1, 1));
            modelBuilder.Entity<Apuesta>().HasData(new Apuesta(2, "1.5", "over", 1.9, 10, 1, 2));
        }

    }
}