using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RepositoryMovie: RepositoryBase<Movie>, IRepositoryMovie
    {
        private readonly ApplicationContext _context;
        public RepositoryMovie(ApplicationContext context) : base(context)
        {
            _context = context;
        }
    
        public ICollection<Movie>? GetAllMovies()
        {
            var listMovies = _context.Movies.Include(m => m.DirectorMovie).Include(m => m.Shows).ToList()
            ?? throw new Exception("Movies not found");
            return listMovies;
        }

        public Movie? GetMoviesById(int Id) 
        {
            var movie = _context.Movies.Include(m => m.DirectorMovie).Include(m => m.Shows).FirstOrDefault(m => m.Id == Id)
                ?? throw new Exception("Movie not found");
            return movie;
        }
    }
}
