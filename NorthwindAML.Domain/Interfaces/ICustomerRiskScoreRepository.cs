using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Domain.Interfaces
{
    public interface ICustomerRiskScoreRepository
    {
        IEnumerable<CustomerRiskScore> GetAll();
        CustomerRiskScore? GetByCustomer(string customerId);
        void Add(CustomerRiskScore score);
        void Update(CustomerRiskScore score);
    }
}
