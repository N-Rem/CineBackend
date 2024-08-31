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
    public class RepositoryShow : IRepositoryShow
    {
        private readonly ApplicationContext _context;
        public RepositoryShow(ApplicationContext context)
        {
            _context = context;
        }


        public List<Show>? GetShows()
        {
            return _context.Shows.ToList();
        }

        public List<Show>? GetShowsByMovieId(int movieId)
        {
            return _context.Shows.Where(s => s.Movie.Id == movieId).ToList();
        }

        public bool ModifyShow(int idShow, DateTime date, decimal price)
        {
            var showToModify = _context.Shows.FirstOrDefault(s => s.Id == idShow);

            if (showToModify is not null)
            {
                showToModify.Date = date;
                showToModify.Price = price;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool DeleteShow(int idShow)
        {
            var showToDelete = _context.Shows.FirstOrDefault(s => s.Id == idShow);

            if (showToDelete is not null)
            {
                _context.Shows.Remove(showToDelete);
                _context.SaveChanges();

                return true;
            }

            return false;
        }


        public void AddShow(DateTime date, decimal price, int movieId)
        {
            var movie = _context.Movies.Find(movieId);

            if (movie == null)
            {
                throw new ArgumentException("Movie not found", nameof(movieId));
            }

            var show = new Show( date, price, movie);
            _context.Shows.Add(show);

            _context.SaveChanges();
        }

        public List<Show> GetShowsByDirectorOnDate(int directorId, DateTime date)
        {
            return _context.Shows
                .Include(s => s.Movie) 
                .Where(s => s.Movie.DirectorId == directorId && s.Date.Date == date.Date)
                .ToList();
        }

        public List<Show> GetShowsByMovieOnDate(int movieId, DateTime date)
        {
            return _context.Shows
                .Where(s => s.Movie.Id == movieId && s.Date.Date == date.Date)
                .ToList();
        }
    }
}
