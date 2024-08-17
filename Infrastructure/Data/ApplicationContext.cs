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
                .WithOne()
                .HasForeignKey(s => s.MovieId) //Error porque no puede acceder al id
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
                new Movie { Id = 1,Title = "John Wick",DirectorId= 1, ImageUrl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTrlMhuTYAKZHxZXA4OzjqcKaopJEjTOzLxnQ&s",Description= "Lorem ipsum dolor sit amet consectetur adipisicing elit. In, quod dolor? Obcaecati vero fuga nisi quos nam? Commodi magnam obcaecati animi deserunt blanditiis tempore ab sint ipsum veritatis. Aliquam, debitis.", Shows = [] },
                new Movie { Id = 2,Title = "Deadpool", DirectorId=2, ImageUrl="https://pics.filmaffinity.com/Deadpool-834516798-mmed.jpg",Description= "Lorem ipsum dolor sit amet consectetur adipisicing elit. In, quod dolor? Obcaecati vero fuga nisi quos nam? Commodi magnam obcaecati animi deserunt blanditiis tempore ab sint ipsum veritatis. Aliquam, debitis.", Shows = [] },
                new Movie { Id = 3,Title = "Spiderman",DirectorId=3, ImageUrl="https://hips.hearstapps.com/hmg-prod/images/spiderman-homecoming-poster-1551691492.jpg",Description= "Lorem ipsum dolor sit amet consectetur adipisicing elit. In, quod dolor? Obcaecati vero fuga nisi quos nam? Commodi magnam obcaecati animi deserunt blanditiis tempore ab sint ipsum veritatis. Aliquam, debitis.", Shows = [] },
            };
        }
        private Director[] CreateDirectorSeedData()
        {
            return new Director[]
            {
                new Director{ Id = 1, Name= "Chad Stahelski"},
                new Director{ Id = 2, Name = "Tim Miller"},
                new Director{ Id = 3, Name = "Jon Watts"},
            };
        }
    }
}