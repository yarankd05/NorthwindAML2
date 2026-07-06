using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;
using NorthwindAML.Infrastructure.Data;

namespace NorthwindAML.Infrastructure.Repositories
{
    public class TransactionFlagRepository : ITransactionFlagRepository
    {
        private readonly NorthwindContext _context;

        public TransactionFlagRepository(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<TransactionFlag> GetAll() => _context.TransactionFlags.ToList();

        public IEnumerable<TransactionFlag> GetByCustomer(string customerId) =>
            _context.TransactionFlags.Where(f => f.CustomerID == customerId).ToList();

        public void Add(TransactionFlag flag)
        {
            _context.TransactionFlags.Add(flag);
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            _context.TransactionFlags.RemoveRange(_context.TransactionFlags);
            _context.SaveChanges();
        }
    }
}