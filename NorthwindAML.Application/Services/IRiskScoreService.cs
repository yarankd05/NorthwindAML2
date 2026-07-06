using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Application.Services
{
    public interface IRiskScoreService
    {
        IEnumerable<CustomerRiskScore> GetAll();
        CustomerRiskScore? GetByCustomer(string customerId);
        int GenerateSARs();
    }
}