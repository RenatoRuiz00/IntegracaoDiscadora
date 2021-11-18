using System.Text.Json.Serialization;

namespace Operacao.Shared.Models.PagSeguro
{
    public class Boleto
    {

        [JsonPropertyName("periodicity")]
        public string Periodicity { get; set; }
        public string Reference { get; set; }
        [JsonPropertyName("firstDueDate")]
        public string FirstDueDate { get; set; }
        [JsonPropertyName("numberOfPayments")]
        public int NumberOfPayments { get; set; }
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }
    }
}
