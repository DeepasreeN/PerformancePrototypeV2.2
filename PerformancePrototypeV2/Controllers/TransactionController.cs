using Microsoft.AspNetCore.Mvc;
using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.Service.Transaction;
using PerformancePrototypeV2.API.Common;

namespace PerformancePrototypeV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ApiResponse<IEnumerable<TransactionDetail>>> Get()
        {
            
            var data = await _transactionService.GetAllTransactionData();
            if (data == null)
            {
                return new ApiResponse<IEnumerable<TransactionDetail>>
                {
                    Success = false,
                    Message = "Transaction not found",
                    Data = null
                };
            }

            return new ApiResponse<IEnumerable<TransactionDetail>>
            {
                Success = true,
                Message = "Transactions retrieved successfully",
                Data = data
            };

        }

        [HttpGet("page")]
        public async Task<ApiResponse<IEnumerable<TransactionDetail>>> GetByPage(int pagesize,int pagenumber=1)
        {

            var data = await _transactionService.GetTransactionData(pagesize,pagenumber);
            if (data == null)
            {
                return new ApiResponse<IEnumerable<TransactionDetail>>
                {
                    Success = false,
                    Message = "Transaction not found",
                    Data = null
                };
            }

            return new ApiResponse<IEnumerable<TransactionDetail>>
            {
                Success = true,
                Message = "Transactions retrieved successfully",
                Data = data
            };

        }

    }
}
