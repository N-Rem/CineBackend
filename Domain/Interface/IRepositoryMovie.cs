using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IRepositoryMovie:IRepositoryBase<Movie>
    {
        List<Movie>? GetAllMovies();
        Movie? GetMoviesById(int Id);
    }
}
