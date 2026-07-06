using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Domain.Interfaces
{
    public interface ITransactionFlagRepository
    {
        IEnumerable<TransactionFlag> GetAll();
        IEnumerable<TransactionFlag> GetByCustomer(string customerId);
        void Add(TransactionFlag flag);
        void DeleteAll();
    }
}
