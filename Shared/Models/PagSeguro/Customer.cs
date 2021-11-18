using System.Text.Json.Serialization;

namespace Operacao.Shared.Models.PagSeguro
{
    public class Customer
    {
        [JsonPropertyName("document")]
        public Document Document { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("phone")]
        public Phone Phone { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }
}
