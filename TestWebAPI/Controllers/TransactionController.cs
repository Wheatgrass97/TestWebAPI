using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Models;
using TestWebAPI.Classes.ResponseClasses;
using TestWebAPI.Helpers;
using System.Text.Json;

namespace TestWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly TestWebAPIContext _context;

        public TransactionController(TestWebAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public string GetAll()
        {
            var transaction = _context.Transactions.ToList();
            return "";
        }

        [HttpGet("ByCurrency")]
        public string GetAllByCurrency(string currencyCode)
        {
            var dbTransactions = _context.Transactions.Where(x=> x.CurrencyCode.ToLower() == currencyCode.ToLower()).ToList();
            var transactions = new Transactions
            {
                transactionList = dbTransactions.Select(t => new Classes.ResponseClasses.Transaction
                {
                    Code = t.Code,
                    Payment = t.Amount + " " + t.CurrencyCode.ToString(),
                    Status = TransactionStatusHelper.TransactionStatusConverter(t.Status)
                }).ToList()
            };

            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions
            {
                WriteIndented = true 
            });
            return json;
        }

        [HttpGet("ByDateRange")]

        public string GetAllByDateRange(string date)
        {
            return "";
        }

        [HttpGet("ByStatus")]

        public string GetAllByStatus(string status)
        {
            return "";
        }
    }
}
