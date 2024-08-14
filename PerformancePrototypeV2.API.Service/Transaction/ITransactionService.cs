using PerformancePrototypeV2.API.DAL.Model;

namespace PerformancePrototypeV2.API.Service.Transaction
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDetail>> GetAllTransactionData();
        Task<IEnumerable<TransactionDetail>> GetTransactionData(int pagesize, int pagenumber);
    }
}
