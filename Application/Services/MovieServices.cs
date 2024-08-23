using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IRepositoryMovie _repositoryMovie;
        public MovieServices(IRepositoryMovie repositoryMovie)
        {
            _repositoryMovie = repositoryMovie;
        }



        public MovieDto GetMovieById(int id)
        {
            var obj = _repositoryMovie.GetById(id)
                ?? throw new Exception("movie not found");

            var dto = MovieDto.Create(obj);
            return dto;
        }

        public List<Movie> GetAll()
        {
            return _repositoryMovie.GetAll();
        }

        public void Create (MovieCreateRequest movieDto)
        {
            var newMovie = new Movie();
            newMovie.Title = movieDto.Title;
            newMovie.Description = movieDto.Description;
            newMovie.ImageUrl = movieDto.ImageUrl;
            newMovie.DirectorId = movieDto.DirectorId;
            _repositoryMovie.Add(newMovie);
        }

        public void UpdateMovie (MovieUpdateRequest movieDto, int id)
        {
            var obj = _repositoryMovie.GetMoviesById(id)
                ?? throw new Exception("movie not found");
            obj.Title = movieDto.Title;
            obj.Description = movieDto.Description;
            obj.ImageUrl = movieDto.ImageUrl;
            obj.DirectorId = movieDto.DirectorId;
            _repositoryMovie.Update(obj);
        }

        public void Delete(int id)
        {
            var obj = _repositoryMovie.GetMoviesById(id)
                ?? throw new Exception("movie not found");
            _repositoryMovie.Delete(obj);

        }


    }
}
