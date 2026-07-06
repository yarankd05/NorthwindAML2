using NorthwindAML.Domain.Entities;
using NorthwindAML.Domain.Interfaces;

namespace NorthwindAML.Application.Services
{
    public class SARService : ISARService
    {
        private readonly ISARRepository _sarRepo;

        public SARService(ISARRepository sarRepo)
        {
            _sarRepo = sarRepo;
        }

        public IEnumerable<SARRecord> GetAll() => _sarRepo.GetAll();
        public SARRecord? GetByCustomer(string customerId) => _sarRepo.GetByCustomer(customerId);

        public void MarkAsReviewed(string customerId)
        {
            var sar = _sarRepo.GetByCustomer(customerId);
            if (sar != null)
            {
                sar.Status = "Reviewed";
                _sarRepo.Update(sar);
            }
        }
    }
}