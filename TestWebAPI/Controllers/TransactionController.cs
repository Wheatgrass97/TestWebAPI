using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestWebAPI.Models;

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
            return "";
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
