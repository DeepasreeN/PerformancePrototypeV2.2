using Microsoft.EntityFrameworkCore;
using PerformancePrototypeV2.API.DAL;
using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.DAL.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace PerformancePrototypeV2.API.DAL.Repositories
{
    public class TransactionRepository : Repository<TransactionDetail>, ITransactionRepository
    {
        private readonly InformationDBContext _context;
        public TransactionRepository(InformationDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<TransactionDetail>> GetpagedTransactionData(int pageSize, int pageNumber)
        {
            var data = await _context.TransactionDetails
                            .OrderBy(x=>x.Id)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
            return data;
        }
    }
}
