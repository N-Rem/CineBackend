using Application.Models;
using Application.Models.Requests;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IShowService
    {
        bool DeleteShow(int idShow);
        List<Show>? GetShowsByMovieId(int movieId);
        bool ModifyShow(int idShow, ShowDto show);
        void AddShow(CeateShowDto show);
    }
}