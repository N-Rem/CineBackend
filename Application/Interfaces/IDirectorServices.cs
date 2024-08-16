using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDirectorServices
    {
        IEnumerable<Director> GetAllDirectors();
        Director? GetDirectorById(int id);
        Director? GetDirectorByName(string name);
        Director AddDirector(Director director);
        void UpdateDirector(Director director);
        void DeleteDirector(int id);
    }
}
