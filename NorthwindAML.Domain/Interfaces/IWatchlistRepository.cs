using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Domain.Interfaces
{
    public interface IWatchlistRepository
    {
        IEnumerable<Watchlist> GetAll();
        Watchlist? GetById(int id);
        void Add(Watchlist watchlist);
        bool IsMatch(string companyName);
    }
}
