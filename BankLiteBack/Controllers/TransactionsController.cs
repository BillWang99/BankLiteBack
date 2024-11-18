using BankLiteBack.Enum;
using BankLiteBack.Interfaces;
using BankLiteBack.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankLiteBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;

        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        [HttpPost]
        public IActionResult AddTransaction(TransactionForm data)
        {
            _transactionsService.AddTranscation(data);

            return Ok();
        }

        [HttpPost("Transfer")]
        public IActionResult TransferMoney(TransferForm data)
        {
            int result = _transactionsService.TransferMoney(data);

            if(result == (int)TransferStatus.success)
            {
                return Ok();
            }
            else
            {
                return BadRequest("金額不可為0且金額不可大於轉出帳戶餘額");
            }
        }
    }
}
