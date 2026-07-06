using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;

namespace NorthwindAML.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IWatchlistRepository _watchlistRepo;
        private readonly ICustomerRiskScoreRepository _riskScoreRepo;

        public CustomerService(
            ICustomerRepository customerRepo,
            IWatchlistRepository watchlistRepo,
            ICustomerRiskScoreRepository riskScoreRepo)
        {
            _customerRepo = customerRepo;
            _watchlistRepo = watchlistRepo;
            _riskScoreRepo = riskScoreRepo;
        }

        public IEnumerable<Customer> GetAll() => _customerRepo.GetAll();
        public Customer? GetById(string id) => _customerRepo.GetById(id);

        public string AddCustomer(Customer customer)
        {
            if (_watchlistRepo.IsMatch(customer.CompanyName))
                return "blocked: name matches watchlist";

            _customerRepo.Add(customer);
            _riskScoreRepo.Add(new CustomerRiskScore
            {
                CustomerID = customer.CustomerID,
                Score = 0,
                LastUpdated = DateTime.Now
            });
            return "customer added successfully";
        }

        public void UpdateCustomer(Customer customer) => _customerRepo.Update(customer);
        public void DeleteCustomer(string id) => _customerRepo.Delete(id);
    }
}
