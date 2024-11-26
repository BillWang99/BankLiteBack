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
        [HttpPost("history")]
        public IActionResult History([FromBody] TransferHistoryForm data)
        {
            var result = _transactionsService.TransferHistory(data);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddTransaction([FromBody] TransactionForm data)
        {
            _transactionsService.AddTranscation(data);

            return Ok();
        }

        [HttpPost("Transfer")]
        public IActionResult TransferMoney([FromBody] TransferForm data)
        {
            int result = _transactionsService.TransferMoney(data);

            if (result == (int)TransferStatus.success)
            {
                return Ok();
            }
            else
            {
                return BadRequest("金額不可為0且金額不可大於轉出帳戶餘額");
            }
        }

        [HttpGet("{id}")]
        public IActionResult TransactionHistoryInfo(int id)
        {
            return  Ok(_transactionsService.TransactionHistoryInfo(id));
        }
    }
}
