using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;

namespace NorthwindAML.Application.Services
{
    public class RiskScoreService : IRiskScoreService
    {
        private readonly ICustomerRiskScoreRepository _riskScoreRepo;
        private readonly ISARRepository _sarRepo;

        public RiskScoreService(
            ICustomerRiskScoreRepository riskScoreRepo,
            ISARRepository sarRepo)
        {
            _riskScoreRepo = riskScoreRepo;
            _sarRepo = sarRepo;
        }

        public IEnumerable<CustomerRiskScore> GetAll() => _riskScoreRepo.GetAll();
        public CustomerRiskScore? GetByCustomer(string customerId) => _riskScoreRepo.GetByCustomer(customerId);

        public int GenerateSARs()
        {
            int count = 0;
            var highRisk = _riskScoreRepo.GetAll().Where(s => s.Score >= 50).ToList();
            foreach (var score in highRisk)
            {
                if (_sarRepo.GetByCustomer(score.CustomerID) == null)
                {
                    _sarRepo.Add(new SARRecord
                    {
                        CustomerID = score.CustomerID,
                        GeneratedDate = DateTime.Now,
                        Summary = $"customer {score.CustomerID} flagged with risk score {score.Score}.",
                        Status = "Open"
                    });
                    count++;
                }
            }
            return count;
        }
    }
}