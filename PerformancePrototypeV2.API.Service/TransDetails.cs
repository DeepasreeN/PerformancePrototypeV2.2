using PerformancePrototypeV2.API.DAL.Model;

namespace PerformancePrototypeV2.API.ViewModel
{
    public class TransDetails
    {
        public int totalcount { get; set; }
        public List<TransactionDetail>? Transactiondetails { get; set; }

    }
}
