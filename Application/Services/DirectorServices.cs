using Domain.Entities;
using Domain.Interface;
using System.Collections.Generic;
using Application.Interfaces;
using static Domain.Interface.IRepositoryDirector;

namespace Application.Services
{
    public class DirectorService : IDirectorServices
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public IEnumerable<Director> GetAllDirectors()
        {
            return _directorRepository.GetAll();
        }

        public Director? GetDirectorById(int id)
        {
            return _directorRepository.GetById(id);
        }

        public Director? GetDirectorByName(string name)
        {
            return _directorRepository.GetByName(name);
        }

        public Director AddDirector(Director director)
        {
            return _directorRepository.Add(director);
        }

        public void UpdateDirector(Director director)
        {
            _directorRepository.Update(director);
        }

        public void DeleteDirector(int id)
        {
            var director = _directorRepository.GetById(id);
            if (director != null)
            {
                _directorRepository.Delete(director);
            }
            else
            {
                throw new Exception("Director not found.");
            }
        }
    }
}

