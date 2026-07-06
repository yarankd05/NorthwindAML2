using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;
using NorthwindAML.Infrastructure.Data;

namespace NorthwindAML.Infrastructure.Repositories
{
    public class SARRepository : ISARRepository
    {
        private readonly NorthwindContext _context;

        public SARRepository(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<SARRecord> GetAll() => _context.SARRecords.ToList();

        public SARRecord? GetByCustomer(string customerId) =>
            _context.SARRecords.FirstOrDefault(s => s.CustomerID == customerId);

        public void Add(SARRecord sar)
        {
            _context.SARRecords.Add(sar);
            _context.SaveChanges();
        }

        public void Update(SARRecord sar)
        {
            _context.SARRecords.Update(sar);
            _context.SaveChanges();
        }
    }
}