using Application.Interfaces;
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

        public bool ModifyShow(int idShow, string startTime, string date, string price)
        {
            return (_ShowRepository.ModifyShow(idShow, startTime, date, price));
        }

        public bool DeleteShow(int idShow)
        {
            return _ShowRepository.DeleteShow(idShow);
        }

        public void AddShow(string startTime, string date, string price, int movieId)
        {
            _ShowRepository.AddShow(startTime, date, price,movieId);
        }
    }
}
