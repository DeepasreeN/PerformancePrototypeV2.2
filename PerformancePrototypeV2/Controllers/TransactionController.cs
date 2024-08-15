using Microsoft.AspNetCore.Mvc;
using PerformancePrototypeV2.API.DAL.Model;
using PerformancePrototypeV2.API.Service.Transaction;
using PerformancePrototypeV2.API.Common;
using PerformancePrototypeV2.API.Service;

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
        public async Task<ApiResponse<IEnumerable<TransactionDetail>>> GetByPage(int pageSize,int skipNumber=0)
        {

            var data = await _transactionService.GetTransactionData(pageSize, skipNumber);
            if (data == null)
            {
                return new ApiResponse<TransDetails>
                {
                    Success = false,
                    Message = "Transaction not found",
                    Data = null
                };
            }

            return new ApiResponse<TransDetails>
            {
                Success = true,
                Message = "Transactions retrieved successfully",
                Data = data
            };

        }
        [HttpGet("count")]
        public  ApiResponse<int> GetTotalCount()
        {

            var data = 100;
            if (data == 0)
            {
                return new ApiResponse<int>
                {
                    Success = false,
                    Message = "Transaction not found",
                    Data = data
                };
            }

            return new ApiResponse<int>
            {
                Success = true,
                Message = "Transactions retrieved successfully",
                Data = data
            };

        }

    }
}
