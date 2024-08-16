using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public class IRepositoryDirector
    {
        public interface IDirectorRepository
        {
            IEnumerable<Director> GetAll();
            Director? GetById(int id);
            Director? GetByName(string name);
            Director Add(Director director);
            void Update(Director director);
            void Delete(Director director);
        }
    }
}
