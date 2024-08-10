using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Show> Shows { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relación de uno a muchos entre Movie y Show
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Shows)
                .WithOne(s => s.Movie)
                .HasForeignKey(s => s.Movie.Id)
                .OnDelete(DeleteBehavior.Cascade); //asegura que si una película se elimina, todas las funciones asociadas también se eliminarán.

            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                .WithOne(m => m.DirectorMovie)
                .HasForeignKey(m => m.DirectorMovie)
                .OnDelete(DeleteBehavior.Cascade); //asegura que si un director se elimina, todas sus peliculas asociadas también se eliminarán.
        }
    }
}