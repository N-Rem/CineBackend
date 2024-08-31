using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Interface.IRepositoryDirector;

namespace Application.Services
{
    public class ShowService : IShowService
    {
        private readonly IRepositoryShow _showRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IRepositoryMovie _movieRepository;

        public ShowService(IRepositoryShow showRepository, IDirectorRepository directorRepository, IRepositoryMovie movieRepository)
        {
            _showRepository = showRepository;
            _directorRepository = directorRepository;
            _movieRepository = movieRepository;
        }

        public List<Show>? GetShowsByMovieId(int movieId)
        {
            return _showRepository.GetShowsByMovieId(movieId);
        }

        public bool ModifyShow(int idShow, ShowDto show)
        {
            return (_showRepository.ModifyShow(idShow, show.Date, show.Price));
        }

        public bool DeleteShow(int idShow)
        {
            return _showRepository.DeleteShow(idShow);
        }

        public void AddShow(CeateShowDto show)
        {
            var movie = _movieRepository.GetById(show.MovieId);
            if (movie == null)
            {
                throw new ArgumentException("Movie not found");
            }

            var director = _directorRepository.GetById(movie.DirectorId);
            if (director == null)
            {
                throw new ArgumentException("Director not found");
            }

            var showsByDirectorOnDate = _showRepository.GetShowsByDirectorOnDate(director.Id, show.Date);
            if (showsByDirectorOnDate.Count >= 10)
            {
                throw new InvalidOperationException("Cannot add more than 10 shows per day for this director.");
            }


            if (!movie.IsNational)
            {
                var showsForMovieOnDate = _showRepository.GetShowsByMovieOnDate(movie.Id, show.Date);
                if (showsForMovieOnDate.Count >= 8)
                {
                    throw new InvalidOperationException("Cannot add more than 8 shows per day for an international movie.");
                }
            }
            _showRepository.AddShow(show.Date, show.Price, show.MovieId);
        }
    }
}
