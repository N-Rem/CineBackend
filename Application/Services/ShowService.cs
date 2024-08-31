using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ShowService : IShowService
    {
        private readonly IRepositoryShow _ShowRepository;

        public ShowService(IRepositoryShow ShowRepository)
        {
            _ShowRepository = ShowRepository;
        }

        public List<Show>? GetShowsByMovieId(int movieId)
        {
            return _ShowRepository.GetShowsByMovieId(movieId);
        }

        public bool ModifyShow(int idShow, ShowDto show)
        {
            return (_ShowRepository.ModifyShow(idShow, show.SartTime, show.Date, show.Price));
        }

        public bool DeleteShow(int idShow)
        {
            return _ShowRepository.DeleteShow(idShow);
        }

        public void AddShow(CeateShowDto show)
        {
            _ShowRepository.AddShow(show.SartTime, show.Date, show.Price, show.MovieId);
        }
    }
}
