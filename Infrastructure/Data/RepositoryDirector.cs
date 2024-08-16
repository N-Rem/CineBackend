using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Domain.Interface.IRepositoryDirector;

namespace Infrastructure.Data
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly ApplicationContext _context;

        public DirectorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Director> GetAll()
        {
            return _context.Directors
                .Include(d => d.Movies) 
                .ToList();
        }

        public Director? GetById(int id)
        {
            return _context.Directors
                .Include(d => d.Movies) 
                .FirstOrDefault(d => d.Id == id);
        }

        public Director? GetByName(string name)
        {
            return _context.Directors
                .Include(d => d.Movies) 
                .FirstOrDefault(d => d.Name == name);
        }

        public Director Add(Director director)
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
            return director;
        }

        public void Update(Director director)
        {
            _context.Directors.Update(director);
            _context.SaveChanges();
        }

        public void Delete(Director director)
        {
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
