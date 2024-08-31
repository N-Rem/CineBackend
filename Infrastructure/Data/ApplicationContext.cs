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
                .HasForeignKey("MovieId") //Error porque no puede acceder al id
                .OnDelete(DeleteBehavior.Cascade); //asegura que si una película se elimina, todas las funciones asociadas también se eliminarán.

            modelBuilder.Entity<Director>()
                .HasMany(d => d.Movies)
                .WithOne(/*m => m.DirectorMovie*/)
                .HasForeignKey(m => m.DirectorId)
                .OnDelete(DeleteBehavior.Cascade); //asegura que si un director se elimina, todas sus peliculas asociadas también se eliminarán.


            //--Crea Movies y Directores--
            modelBuilder.Entity<Movie>().HasData(CreateMovieSeedData());
            modelBuilder.Entity<Director>().HasData(CreateDirectorSeedData());
        }

        private Movie[] CreateMovieSeedData()
        {
            return new Movie[]
            {
                new Movie
                {
                    Id = 1,
                    Title = "John Wick",
                    DirectorId = 1,
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrlMhuTYAKZHxZXA4OzjqcKaopJEjTOzLxnQ&s",
                    Description = "Un asesino a sueldo sale de su retiro para vengarse de los que le hicieron daño.",
                    Shows = new List<Show>(),
                    IsNational = false
                },
                new Movie
                {
                    Id = 2,
                    Title = "Deadpool",
                    DirectorId = 2,
                    ImageUrl = "https://pics.filmaffinity.com/Deadpool-834516798-mmed.jpg",
                    Description = "Un mercenario con habilidades de curación acelerada busca venganza.",
                    Shows = new List<Show>(),
                    IsNational = false
                },
                new Movie
                {
                    Id = 3,
                    Title = "Spiderman",
                    DirectorId = 3,
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/spiderman-homecoming-poster-1551691492.jpg",
                    Description = "Un joven adquiere habilidades arácnidas después de ser mordido por una araña radioactiva.",
                    Shows = new List<Show>(),
                    IsNational = false
                },

                new Movie
                {
                    Id = 4,
                    Title = "El secreto de sus ojos",
                    DirectorId = 4,
                    ImageUrl = "https://m.media-amazon.com/images/I/61dlTXqaMLL._AC_SL1024_.jpg",
                    Description = "Un ex funcionario judicial decide escribir una novela basada en un caso real que lo afectó profundamente.",
                    Shows = new List<Show>(),
                    IsNational = true
                },
                new Movie
                {
                    Id = 5,
                    Title = "Relatos salvajes",
                    DirectorId = 5,
                    ImageUrl = "https://pics.filmaffinity.com/relatos_salvajes-285164385-large.jpg",
                    Description = "Una serie de seis cortometrajes que exploran la violencia y la venganza en diferentes formas.",
                    Shows = new List<Show>(),
                    IsNational = true
                },
                new Movie
                {
                    Id = 6,
                    Title = "Nueve reinas",
                    DirectorId = 6,
                    ImageUrl = "https://m.media-amazon.com/images/I/71aA-cKYcWL._AC_SL1500_.jpg",
                    Description = "Dos estafadores intentan vender una serie de sellos falsos extremadamente valiosos.",
                    Shows = new List<Show>(),
                    IsNational = true
                }
            };
        }
        private Director[] CreateDirectorSeedData()
        {
            return new Director[]
            {
                new Director{ Id = 1, Name= "Chad Stahelski"},
                new Director{ Id = 2, Name = "Tim Miller"},
                new Director{ Id = 3, Name = "Jon Watts"},
                new Director{ Id = 4, Name = "Juan José Campanella" }, 
                new Director{ Id = 5, Name = "Damián Szifron" },
                new Director{ Id = 6, Name = "Fabián Bielinsky" }        
            };
        }
    }
}