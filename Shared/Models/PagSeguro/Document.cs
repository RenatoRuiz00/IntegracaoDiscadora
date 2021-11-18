using System.Text.Json.Serialization;

namespace Operacao.Shared.Models.PagSeguro
{
    public class Document
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
