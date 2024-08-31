using Domain.Entities;

namespace Infrastructure.Data
{
    public interface IRepositoryShow
    {
        bool DeleteShow(int idShow);
        List<Show>? GetShows();
        List<Show>? GetShowsByMovieId(int movieId);
        bool ModifyShow(int idShow, DateTime date, decimal price);

        void AddShow(DateTime date, decimal price, int movieId);
        public List<Show> GetShowsByDirectorOnDate(int directorId, DateTime date);
        public List<Show> GetShowsByMovieOnDate(int movieId, DateTime date);
    }
}