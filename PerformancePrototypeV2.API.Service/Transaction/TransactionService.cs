using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.DAL.Repositories;

namespace PerformancePrototypeV2.API.Service.Transaction
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<IEnumerable<TransactionDetail>> GetAllTransactionData()
        {
            var transaction = await _transactionRepository.GetAllAsync();
            var transactionData = transaction.Take(10);
            return transaction;
        }

        public async Task<IEnumerable<TransactionDetail>> GetTransactionData(int pagesize, int pagenumber)
        {
            var transaction = await _transactionRepository.GetpagedTransactionData(pagesize, pagenumber);
            return transaction;

        }
    }
}
