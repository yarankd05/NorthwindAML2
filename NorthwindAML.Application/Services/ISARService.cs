using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Application.Services
{
    public interface ISARService
    {
        IEnumerable<SARRecord> GetAll();
        SARRecord? GetByCustomer(string customerId);
        void MarkAsReviewed(string customerId);
    }
}