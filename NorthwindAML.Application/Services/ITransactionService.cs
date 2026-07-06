using NorthwindAML.Domain.Entities;

namespace NorthwindAML.Application.Services
{
    public interface ITransactionService
    {
        IEnumerable<TransactionFlag> GetAllFlags();
        IEnumerable<TransactionFlag> GetFlagsByCustomer(string customerId);
        int ScanAndFlagTransactions();
    }
}