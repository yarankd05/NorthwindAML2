using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;
using NorthwindAML.Infrastructure.Data;

namespace NorthwindAML.Infrastructure.Repositories
{
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly NorthwindContext _context;

        public WatchlistRepository(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<Watchlist> GetAll() => _context.Watchlists.ToList();

        public Watchlist? GetById(int id) => _context.Watchlists.Find(id);

        public void Add(Watchlist watchlist)
        {
            _context.Watchlists.Add(watchlist);
            _context.SaveChanges();
        }

        public bool IsMatch(string companyName)
        {
            return _context.Watchlists.Any(w =>
                w.FlaggedName != null &&
                (w.FlaggedName.Contains(companyName) ||
                companyName.Contains(w.FlaggedName)));
        }
    }
}