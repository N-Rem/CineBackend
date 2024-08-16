using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int DirectorId { get; set; }
        public DirectorDto DirectorMovie { get; set; }
        public List<ShowDto> Shows { get; set; }

        public static MovieDto Create(Movie movie)
        {
            var NewMovie = new MovieDto();
            NewMovie.Id = movie.Id;
            NewMovie.Title = movie.Title;
            NewMovie.Description = movie.Description;
            NewMovie.ImageUrl = movie.ImageUrl;
            NewMovie.DirectorId = movie.DirectorId;
            //NewMovie.DirectorMovie = funcion que crea dto de director
            return NewMovie;
        }
        public static ICollection<MovieDto> CreateList(IEnumerable<Movie> movies)
        {
            var MovieList = new List<MovieDto>();
            foreach (Movie m in movies)
            {
                MovieList.Add(Create(m));
            }
            return MovieList;
        }

    }
}
