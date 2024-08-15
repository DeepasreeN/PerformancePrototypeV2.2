using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.ViewModel;

namespace PerformancePrototypeV2.API.Service.Transaction
{
    public interface ITransactionService
    {
        Task<IEnumerable<TransactionDetail>> GetAllTransactionData();
        Task<TransDetails> GetTransactionData(int pagesize, int skipnumber);
    }
}
