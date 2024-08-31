using Domain.Entities;

namespace Infrastructure.Data
{
    public interface IRepositoryShow
    {
        bool DeleteShow(int idShow);
        List<Show>? GetShows();
        List<Show>? GetShowsByMovieId(int movieId);
        bool ModifyShow(int idShow, string startTime, string date, string price);

        void AddShow(string startTime, string date, string price, int movieId);
    }
}