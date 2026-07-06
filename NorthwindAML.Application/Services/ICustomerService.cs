using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Application.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer? GetById(string id);
        string AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(string id);
    }
}