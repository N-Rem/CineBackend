using Domain.Entities;

namespace Application.Interfaces
{
    public interface IShowService
    {
        bool DeleteShow(int idShow);
        List<Show>? GetShowsByMovieId(int movieId);
        bool ModifyShow(int idShow, string startTime, string date, string price);
        void AddShow(string startTime, string date, string price);
    }
}