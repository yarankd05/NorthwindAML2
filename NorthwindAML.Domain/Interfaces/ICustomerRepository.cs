using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(string id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(string id);
    }
}
