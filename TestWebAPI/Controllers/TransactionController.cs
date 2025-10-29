using Microsoft.AspNetCore.Mvc;
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
            var dbTransactions = _context.Transactions.ToList();
            var transactions = new Transactions
            {
                transactionList = dbTransactions.Select(t => new Classes.ResponseClasses.Transaction
                {
                    Code = t.Code,
                    Payment = t.Amount + " " + t.CurrencyCode.ToString(),
                    Status = TransactionStatusHelper.TsConvertToStr(t.Status)
                }).ToList()
            };

            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return json;
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
                    Status = TransactionStatusHelper.TsConvertToStr(t.Status)
                }).ToList()
            };

            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions
            {
                WriteIndented = true 
            });
            return json;
        }

        [HttpGet("ByDateRange")]

        public string GetAllByDateRange(string dateFrom, string dateTo)
        {
            DateTime dateFromParsed;
            DateTime dateToParsed;
            
            if (!DateTime.TryParse(dateFrom, out dateFromParsed) || !DateTime.TryParse(dateTo, out dateToParsed))
            {
                return "Invalid date format. Please use a valid date format.";
            }
           
            var dbTransactions = _context.Transactions
                .Where(x => x.CreatedDate >= dateFromParsed && x.CreatedDate <= dateToParsed.Date.AddDays(1).AddTicks(-1))
                .ToList();
            var transactions = new Transactions
            {
                transactionList = dbTransactions.Select(t => new Classes.ResponseClasses.Transaction
                {
                    Code = t.Code,
                    Payment = t.Amount + " " + t.CurrencyCode.ToString(),
                    Status = TransactionStatusHelper.TsConvertToStr(t.Status)
                }).ToList()
            };
            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return json;
        }
     
        [HttpGet("ByStatus")]

        public string GetAllByStatus(string status)
        {
            int statusInt = TransactionStatusHelper.TsConvertToInt(status);
            var dbTransactions = _context.Transactions.Where(x => x.Status == statusInt).ToList();
            var transactions = new Transactions
            {
                transactionList = dbTransactions.Select(t => new Classes.ResponseClasses.Transaction
                {
                    Code = t.Code,
                    Payment = t.Amount + " " + t.CurrencyCode.ToString(),
                    Status = TransactionStatusHelper.TsConvertToStr(t.Status)
                }).ToList()
            };

            string json = JsonSerializer.Serialize(transactions, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            return json;
        }
    }
}
