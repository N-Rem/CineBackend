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
            return _context.Shows.Where(s => s.MovieId == movieId).ToList();
        }

        public bool ModifyShow(int idShow, string startTime, string date, string price)
        {
            var showToModify = _context.Shows.FirstOrDefault(s => s.Id == idShow);

            if (showToModify is not null)
            {
                showToModify.StartTime = startTime;
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


        public void AddShow(string startTime, string date, string price, int movieId)
        {
            var show = new Show(startTime, date, price, movieId);

            var movie = _context.Movies.Include(m => m.Shows).FirstOrDefault(m => m.Id == movieId);

            if (movie is not null)
                movie.Shows.Add(show);

            _context.SaveChanges();
        }
    }
}
