using System.Text.Json.Serialization;

namespace Operacao.Shared.Models.PagSeguro
{
    public class Phone
    {
        [JsonPropertyName("areaCode")]
        public string AreaCode { get; set; }
        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}
