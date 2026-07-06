using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;
using NorthwindAML.Infrastructure.Data;

namespace NorthwindAML.Infrastructure.Repositories
{
    public class CustomerRiskScoreRepository : ICustomerRiskScoreRepository
    {
        private readonly NorthwindContext _context;

        public CustomerRiskScoreRepository(NorthwindContext context)
        {
            _context = context;
        }

        public IEnumerable<CustomerRiskScore> GetAll() => _context.CustomerRiskScores.ToList();

        public CustomerRiskScore? GetByCustomer(string customerId) =>
            _context.CustomerRiskScores.FirstOrDefault(r => r.CustomerID == customerId);

        public void Add(CustomerRiskScore score)
        {
            _context.CustomerRiskScores.Add(score);
            _context.SaveChanges();
        }

        public void Update(CustomerRiskScore score)
        {
            _context.CustomerRiskScores.Update(score);
            _context.SaveChanges();
        }
    }
}