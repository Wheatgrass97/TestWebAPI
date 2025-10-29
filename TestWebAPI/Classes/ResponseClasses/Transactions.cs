using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestWebAPI.Classes.ResponseClasses
{
    public class Transactions
    {
        public List<Transaction> transactionList { get; set; }
    }

    public class Transaction {
        [JsonPropertyName("id")]
        [StringLength(50)]
        public string? Code { get; set; }

        [JsonPropertyName("payment")]
        public string Payment { get; set; }

        //[JsonPropertyName("CurrencyCode")]
        //[StringLength(3)]
        //public string? CurrencyCode { get; set; }

        //[JsonPropertyName("CreatedDate")]
        //public DateTime CreatedDate { get; set; }

        [JsonPropertyName("Status")]
        public string Status { get; set; }
    }
}
