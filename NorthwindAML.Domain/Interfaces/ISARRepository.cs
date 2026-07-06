using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Domain.Interfaces
{
    public interface ISARRepository
    {
        IEnumerable<SARRecord> GetAll();
        SARRecord? GetByCustomer(string customerId);
        void Add(SARRecord sar);
        void Update(SARRecord sar);
    }
}
