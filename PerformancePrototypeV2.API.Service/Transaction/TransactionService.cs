using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.DAL.Repositories;
using PerformancePrototypeV2.API.ViewModel;

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
            //var transactionData = transaction.Take(10);
            return transaction;
        }

        public async Task<TransDetails> GetTransactionData(int pagesize, int pagenumber)
        {
            var transactionRecords = await _transactionRepository.GetPagedTransactionData(pagesize, pagenumber);
            var recordCount = await _transactionRepository.GetTotalRecordCount();

            var transactions = new TransDetails();
            return transactions;

        }
    }
}
