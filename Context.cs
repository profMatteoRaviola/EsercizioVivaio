using EsercizioVivaio.Classi_Modello;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace EsercizioVivaio
{
    class Context : DbContext
    {
        public DbSet<Cliente> Clienti { get; set; } //entità Clienti
        public DbSet<Pianta> Piante { get; set; } //entità Piante
        public DbSet<Ordine> Ordini { get; set; } //entità Ordini

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging()
                .UseSqlite(@"Data Source = ... ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Fiore>()
                .HasOne(p => p.Pianta)
                .WithOne(p => p.Fiore).IsRequired(true);

            modelBuilder.Entity<Giardino>()
                .HasOne(p => p.Pianta)
                .WithOne(p => p.Giardino).IsRequired(true);

            modelBuilder.Entity<Frutta>()
                .HasOne(p => p.Pianta)
                .WithOne(p => p.Frutta).IsRequired(true);*/

            modelBuilder.Entity<Cliente>().HasMany(p => p.Ordini).WithOne(p => p.Cliente).IsRequired();

            modelBuilder.Entity<Pianta>().HasOne(p => p.Fiore).WithOne(p => p.Pianta).IsRequired(false);
            modelBuilder.Entity<Pianta>().HasOne(p => p.Frutta).WithOne(p => p.Pianta).IsRequired(false);
            modelBuilder.Entity<Pianta>().HasOne(p => p.Giardino).WithOne(p => p.Pianta).IsRequired(false);

        }



    }
}
